using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SpartanBoosting.Extensions;
using SpartanBoosting.Extensions.LolExtensions;
using SpartanBoosting.Models;
using SpartanBoosting.Models.LeagueOfLegends_Models.Pricing;
using SpartanBoosting.Models.Pricing;
using SpartanBoosting.Repositorys.Interfaces;
using SpartanBoosting.Utils;
using SpartanBoosting.ViewModel;
using static SpartanBoosting.Utils.PurchaseTypeEnum;

namespace SpartanBoosting.Controllers
{
	public class InvoiceController : Controller
	{
		private PricingController PricingController { get; set; }
		private readonly UserManager<ApplicationUser> _userManager;
		public InvoiceController(ILogger<PricingController> logger, IDiscountModelRepository discountModelRepository, UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
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
		public IActionResult CreateInvoice(PurchaseForm purchaseForm)
		{
			purchaseForm.PersonalInformation.Email = User.Identity.IsAuthenticated ? User.Identity.Name : purchaseForm.PersonalInformation.Email;
			purchaseForm = LolModelExtenstion.AssignModel(purchaseForm, TempData["OrderModel"].ToString());

			//recheck price because they could edit the request
			PricingResponse Pricing = JsonConvert.DeserializeObject<PricingResponse>(JsonConvert.SerializeObject(PricingController.SoloPricing(purchaseForm).Value));
			purchaseForm.Pricing = Pricing.Price.ToString();
			purchaseForm.Discount = Pricing.DiscountModel;

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
				TempData["purchaseFormlData"] = JsonConvert.SerializeObject(purchaseForm);
				return Redirect(paypalResult.ApprovalURL);
			}
			else
			{
				try
				{
					var result = StripePayments.StripePaymentsForm(purchaseForm.PersonalInformation.Email, purchaseForm.PersonalInformation.stripeToken, Pricing.Price.ToString());
					if (result.Status == "succeeded" && result.Paid)
					{
						TempData["purchaseFormlData"] = JsonConvert.SerializeObject(purchaseForm);
						return RedirectToAction("PurchaseQuote", "Quote");
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
						return "Lol Username and Password is needed for this type of boost!";
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