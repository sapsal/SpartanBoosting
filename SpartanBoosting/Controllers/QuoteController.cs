using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SpartanBoosting.Models.Pricing;
using SpartanBoosting.Utils;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Threading.Tasks;
using System;

namespace SpartanBoosting.Controllers
{
	public class QuoteController : Controller
	{
		private readonly IOptions<SmtpSettings> _smtpSettings;
		private ICompositeViewEngine _viewEngine;

		public QuoteController(IOptions<SmtpSettings> smtpSettings, ICompositeViewEngine viewEngine)
		{
			_smtpSettings = smtpSettings;
			_viewEngine = viewEngine;
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

		public IActionResult PurchaseQuote()
		{
			try
			{
				PurchaseForm purchaseForm = JsonConvert.DeserializeObject<PurchaseForm>(TempData["purchaseFormlData"].ToString());
				EmailSender email = new EmailSender(_smtpSettings);

				//var bot = new DiscordBot();
				//bot.RunAsync(purchaseForm).GetAwaiter().GetResult();
				string emailbody = string.Empty;
				switch (purchaseForm.PurchaseType)
				{
					case PurchaseTypeEnum.PurchaseType.SoloBoosting:
						emailbody = RenderPartialViewToString("Templates/PurchaseOrderSoloEmail", purchaseForm).Result;
						break;
					case PurchaseTypeEnum.PurchaseType.DuoBoosting:
						emailbody = RenderPartialViewToString("Templates/PurchaseOrderDuoEmail", purchaseForm).Result;
						break;
					case PurchaseTypeEnum.PurchaseType.WinBoosting:
						 emailbody = RenderPartialViewToString("Templates/PurchaseOrderWinBoostEmail", purchaseForm).Result;
						break;
					case PurchaseTypeEnum.PurchaseType.PlacementMatches:
						 emailbody = RenderPartialViewToString("Templates/PurchaseOrderPlacementMatchesEmail", purchaseForm).Result;
						break;
					case PurchaseTypeEnum.PurchaseType.TFTPlacement:
						 emailbody = RenderPartialViewToString("Templates/PurchaseOrderTFTPlacementMatchesEmail", purchaseForm).Result;
						break;
					case PurchaseTypeEnum.PurchaseType.TFTBoosting:
						 emailbody = RenderPartialViewToString("Templates/PurchaseOrderTFTSoloBoostEmail", purchaseForm).Result;
						break;
					//	var emailbody = RenderPartialViewToString("Templates/PurchaseOrderEmail", purchaseForm).Result;
					//	var emailbody = RenderPartialViewToString("Templates/PurchaseOrderEmail", purchaseForm).Result;
					//	break;
					default:
						emailbody = JsonConvert.SerializeObject(purchaseForm);
						break;
				}
				email.SendEmailAsync("Purchase Request", $"Purchase Request", emailbody);
			}
			catch (Exception e)
			{
			}

			return RedirectToAction("Index", "Home");
		}
	}
}