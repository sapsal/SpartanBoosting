using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SpartanBoosting.Extensions;
using SpartanBoosting.Extensions.LolExtensions;
using SpartanBoosting.Models;
using SpartanBoosting.Models.LeagueOfLegends_Models.Pricing;
using SpartanBoosting.Models.Pricing;
using SpartanBoosting.Models.Repositorys;
using SpartanBoosting.Repositorys.Interfaces;
using SpartanBoosting.Utils;
using SpartanBoosting.ViewModel;
using static SpartanBoosting.Utils.PurchaseTypeEnum;

namespace SpartanBoosting.Controllers
{
	public class InvoiceController : Controller
	{
		private readonly IOptions<SmtpSettings> _smtpSettings;
		private ICompositeViewEngine _viewEngine;
		private IPurchaseOrderRepository PurchaseOrderRepository;
		private PricingController PricingController { get; set; }
		private readonly UserManager<ApplicationUser> _userManager;
		private IDiscountModelRepository DiscountModelRepository;
		public InvoiceController(IOptions<SmtpSettings> smtpSettings, ICompositeViewEngine viewEngine, IPurchaseOrderRepository purchaseOrderRepository, ILogger<PricingController> logger, IDiscountModelRepository discountModelRepository, UserManager<ApplicationUser> userManager)
		{
			_smtpSettings = smtpSettings;
			_viewEngine = viewEngine;
			PurchaseOrderRepository = purchaseOrderRepository;
			_userManager = userManager;
			DiscountModelRepository = discountModelRepository;
			this.PricingController = new PricingController(logger, discountModelRepository);
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Details([FromQuery(Name = "data")] string data, [FromQuery(Name = "dest")] string dest)
		{
			InvoiceViewModel InvoiceViewModel = new InvoiceViewModel();
			InvoiceViewModel.PurchaseForm = TempData.Get<PurchaseForm>("purchaseForm");

			//for refresh
			TempData.Put("purchaseForm", InvoiceViewModel.PurchaseForm);

			if (InvoiceViewModel.PurchaseForm != null)
				return View(InvoiceViewModel);
			else
			{
				return RedirectToAction(EncryptionHelper.Decrypt(data), EncryptionHelper.Decrypt(dest));
			}
		}

		[ValidateAntiForgeryToken()]
		[HttpPost]
		public async Task<IActionResult> CreateInvoice(PurchaseForm purchaseForm)
		{
			purchaseForm.PersonalInformation.Email = User.Identity.IsAuthenticated ? User.Identity.Name : purchaseForm.PersonalInformation.Email;
			purchaseForm = LolModelExtenstion.AssignModel(purchaseForm, TempData["OrderModel"].ToString());

			//recheck price because they could edit the request
			PricingResponse Pricing = ValidatePricing(purchaseForm);
			purchaseForm.Pricing = Pricing.Price.ToString();
			purchaseForm.Discount = Pricing.DiscountModel;
			if (User.Identity.IsAuthenticated)
			{
				var user = await _userManager.FindByEmailAsync(User.Identity.Name);
				purchaseForm.ClientAssignedTo = user;
			}


			//validation
			string validationResult = ValidatePaymentInformation(purchaseForm);
			if (!string.IsNullOrEmpty(validationResult))
			{
				TempData.Put("purchaseForm", purchaseForm);
				TempData["validationResult"] = validationResult;
				return RedirectToAction("Details", "Invoice", new { data = EncryptionHelper.Encrypt(purchaseForm.PurchaseType.ToString()), dest = EncryptionHelper.Encrypt("LolBoosting") });
			}

			if (purchaseForm.PersonalInformation.PaymentMethod == "Paypal")
			{
				var paypalResult = PayPalV2.createOrder(Pricing.Price.ToString());
				purchaseForm.PayPalApproval = paypalResult.ApprovalURL;
				purchaseForm.PayPalCapture = paypalResult.CaptureURL;
				TempData.Put("purchaseForm", purchaseForm);
				return Redirect(paypalResult.ApprovalURL);
			}
			else
			{
				try
				{
					var result = StripePayments.StripePaymentsForm(purchaseForm.PersonalInformation.Email, purchaseForm.PersonalInformation.stripeToken, Pricing.Price.ToString());
					if (result.Status == "succeeded" && result.Paid)
					{
						TempData.Put("purchaseForm", purchaseForm);
						return RedirectToAction("InvoiceComplete", "Invoice");
					}
				}
				catch (Exception e)
				{
					TempData["StripePayment"] = "Stripe Payment has failed, please check your details and try again";
					return RedirectToAction("soloboosting", "lolboosting");
				}
				//something went wrong
				return View();
			}
		}

		public async Task<string> RenderPartialViewToString(string viewName, object model)
		{
			if (string.IsNullOrEmpty(viewName))
				viewName = ControllerContext.ActionDescriptor.ActionName;

			ViewData.Model = model;

			using (var writer = new StringWriter())
			{
				ViewEngineResult viewResult =
					_viewEngine.FindView(ControllerContext, viewName, false);

				ViewContext viewContext = new ViewContext(
					ControllerContext,
					viewResult.View,
					ViewData,
					TempData,
					writer,
					new HtmlHelperOptions()
				);

				await viewResult.View.RenderAsync(viewContext);

				return writer.GetStringBuilder().ToString();
			}
		}

		public IActionResult InvoiceDetails()
		{
			try
			{
				PurchaseForm purchaseForm = JsonConvert.DeserializeObject<PurchaseForm>(TempData["completePurchaseForm"].ToString());
				TempData.Put("completePurchaseForm", purchaseForm);
				return View(purchaseForm);
			}
			catch (Exception e)
			{
			}

			return View();
		}

		public IActionResult InvoiceComplete()
		{
			try
			{
				PurchaseForm purchaseForm = JsonConvert.DeserializeObject<PurchaseForm>(TempData["purchaseForm"].ToString());
				EmailSender email = new EmailSender(_smtpSettings);

				if (purchaseForm.PersonalInformation.PaymentMethod == "Paypal")
				{
					PayPalV2.captureOrder(purchaseForm.PayPalCapture);
				}

				purchaseForm = PurchaseOrderRepository.Add(purchaseForm);
				if (purchaseForm.Discount != null && purchaseForm.Discount.SingleUse)
				{
					DiscountModelRepository.SetNotInUse(purchaseForm.Discount);
				}

				var bot = new DiscordBot();
				bot.RunAsync(purchaseForm).GetAwaiter().GetResult();


				string emailbody = string.Empty;
				switch (purchaseForm.PurchaseType)
				{
					case PurchaseTypeEnum.PurchaseType.SoloBoosting:
						emailbody = RenderPartialViewToString("EmailTemplates/PurchaseOrderSoloEmail", purchaseForm).Result;
						break;
					case PurchaseTypeEnum.PurchaseType.DuoBoosting:
						emailbody = RenderPartialViewToString("EmailTemplates/PurchaseOrderDuoEmail", purchaseForm).Result;
						break;
					case PurchaseTypeEnum.PurchaseType.WinBoosting:
						emailbody = RenderPartialViewToString("EmailTemplates/PurchaseOrderWinBoostEmail", purchaseForm).Result;
						break;
					case PurchaseTypeEnum.PurchaseType.PlacementMatches:
						emailbody = RenderPartialViewToString("EmailTemplates/PurchaseOrderPlacementMatchesEmail", purchaseForm).Result;
						break;
					case PurchaseTypeEnum.PurchaseType.TFTPlacement:
						emailbody = RenderPartialViewToString("EmailTemplates/PurchaseOrderTFTPlacementMatchesEmail", purchaseForm).Result;
						break;
					case PurchaseTypeEnum.PurchaseType.TFTBoosting:
						emailbody = RenderPartialViewToString("EmailTemplates/PurchaseOrderTFTSoloBoostEmail", purchaseForm).Result;
						break;
					default:
						emailbody = JsonConvert.SerializeObject(purchaseForm);
						break;
				}
				email.SendEmailAsync(purchaseForm.PersonalInformation.Email, $"Purchase Order", emailbody);

				if (User.Identity.IsAuthenticated)
					return RedirectToAction("OrderDetails", "ClientArea", new { hash = EncryptionHelper.Encrypt(purchaseForm.Id) });
				else
				{
					TempData.Put("completePurchaseForm", purchaseForm);
					return RedirectToAction("InvoiceDetails", "Invoice");
				}
			}
			catch (Exception e)
			{
			}

			return View();
		}

		private PricingResponse ValidatePricing(PurchaseForm purchaseForm)
		{

			switch (purchaseForm.PurchaseType)
			{
				case Utils.PurchaseTypeEnum.PurchaseType.DuoBoosting:
					return JsonConvert.DeserializeObject<PricingResponse>(JsonConvert.SerializeObject(PricingController.DuoPricing(purchaseForm).Value));
				case Utils.PurchaseTypeEnum.PurchaseType.SoloBoosting:
					return JsonConvert.DeserializeObject<PricingResponse>(JsonConvert.SerializeObject(PricingController.SoloPricing(purchaseForm).Value));
				case Utils.PurchaseTypeEnum.PurchaseType.WinBoosting:
					return JsonConvert.DeserializeObject<PricingResponse>(JsonConvert.SerializeObject(PricingController.WinBoostPricing(purchaseForm).Value));
				case Utils.PurchaseTypeEnum.PurchaseType.PlacementMatches:
					return JsonConvert.DeserializeObject<PricingResponse>(JsonConvert.SerializeObject(PricingController.PlacementBoostPricing(purchaseForm).Value));
				case Utils.PurchaseTypeEnum.PurchaseType.TFTPlacement:
					return JsonConvert.DeserializeObject<PricingResponse>(JsonConvert.SerializeObject(PricingController.TFTPlacementBoostPricing(purchaseForm).Value));
				case Utils.PurchaseTypeEnum.PurchaseType.TFTBoosting:
					return JsonConvert.DeserializeObject<PricingResponse>(JsonConvert.SerializeObject(PricingController.TFTSoloBoostPricing(purchaseForm).Value));
			}
			return null;
		}

		private string ValidatePaymentInformation(PurchaseForm purchaseForm)
		{
			if (User.Identity.IsAuthenticated)
			{
				return "";
			}
			else if (string.IsNullOrEmpty(purchaseForm.PersonalInformation.Email))
			{
				if (!(purchaseForm.PurchaseType == PurchaseTypeEnum.PurchaseType.DuoBoosting || purchaseForm.PurchaseType == PurchaseTypeEnum.PurchaseType.WinBoosting ||
										  (purchaseForm.PlacementMatchesModel != null && purchaseForm.PurchaseType == PurchaseTypeEnum.PurchaseType.PlacementMatches && purchaseForm.PlacementMatchesModel.TypeOfService == "Duo")))
				{
					if (string.IsNullOrEmpty(purchaseForm.PersonalInformation.UserName) || string.IsNullOrEmpty(purchaseForm.PersonalInformation.Password))
						return "Lol Username and Password is needed for this type of boost alternatively you can Login/Register!";
				}
				if (string.IsNullOrEmpty(purchaseForm.PersonalInformation.Email))
					return "Please Login/Register or provide an Email under Guest Account!";
				if (string.IsNullOrEmpty(purchaseForm.PersonalInformation.Discord))
					return "Please Login/Register or provide an Discord under Guest Account!";
			}
			return "";
		}
	}
}