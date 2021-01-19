using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SpartanBoosting.Extensions;
using SpartanBoosting.Models;
using SpartanBoosting.Models.LeagueOfLegends_Models.Pricing;
using SpartanBoosting.Models.Pricing;
using SpartanBoosting.Repositorys.Interfaces;
using SpartanBoosting.Utils;
using static SpartanBoosting.Utils.PurchaseTypeEnum;

namespace SpartanBoosting.Controllers
{
	public class TFTBoostingController : Controller
	{
		private PricingController PricingController { get; set; }
		public TFTBoostingController(ILogger<PricingController> logger, IDiscountModelRepository discountModelRepository)
		{
			this.PricingController = new PricingController(logger, discountModelRepository);
		}
		[ValidateAntiForgeryToken()]
		[HttpPost]
		public IActionResult SubmitToOrder(PurchaseForm purchaseForm)
		{
			TempData.Put("purchaseForm", purchaseForm);

			return RedirectToAction("Details", "Invoice", new { data = EncryptionHelper.Encrypt(purchaseForm.PurchaseType.ToString()), dest = EncryptionHelper.Encrypt("LolBoosting") });
		}
		public IActionResult TFTPlacementMatches()
		{
			PurchaseForm model = new PurchaseForm();
			model.Discount = new DiscountModel();
			model.PurchaseType = PurchaseType.TFTPlacement;
			return View(model);
		}
		public IActionResult TFTSoloBoost()
		{
			PurchaseForm model = new PurchaseForm();
			model.Discount = new DiscountModel();
			model.PurchaseType = PurchaseType.TFTBoosting;
			return View(model);
		}

		[ValidateAntiForgeryToken()]
		[HttpPost]
		public IActionResult CreateTFTSoloBoost(Models.TFTBoostingModel BoostingModel, Models.PersonalInformation PersonalInformation)
		{
			PurchaseForm purchaseForm = new PurchaseForm { TFTBoostingModel = BoostingModel, PersonalInformation = PersonalInformation };
			PricingResponse Pricing = JsonConvert.DeserializeObject<PricingResponse>(JsonConvert.SerializeObject(PricingController.TFTSoloBoostPricing(purchaseForm).Value));
			purchaseForm.Pricing = Pricing.Price;
			purchaseForm.Discount = Pricing.DiscountModel;
			if (PersonalInformation.PaymentMethod == "Paypal")
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
					var result = StripePayments.StripePaymentsForm(PersonalInformation, Pricing.Price.ToString());
					if (result.Status == "succeeded" && result.Paid)
					{
						TempData["purchaseFormlData"] = JsonConvert.SerializeObject(purchaseForm);

						return RedirectToAction("PurchaseQuote", "Quote");
					}
				}
				catch (Exception e)
				{
					TempData["StripePayment"] = "Stripe Payment has failed, please check your details and try again";
					return RedirectToAction("TFTSoloBoost", "TFTBoosting");
				}

				//something went wrong
				return View();
			}
		}
		[ValidateAntiForgeryToken()]
		[HttpPost]
		public IActionResult CreateTFTPlacementBoost(Models.TFTPlacementModel BoostingModel, Models.PersonalInformation PersonalInformation)
		{
			PurchaseForm purchaseForm = new PurchaseForm { TFTPlacementModel = BoostingModel, PersonalInformation = PersonalInformation };
			PricingResponse Pricing = JsonConvert.DeserializeObject<PricingResponse>(JsonConvert.SerializeObject(PricingController.TFTPlacementBoostPricing(purchaseForm).Value));
			purchaseForm.Pricing = Pricing.Price;
			purchaseForm.Discount = Pricing.DiscountModel;
			if (PersonalInformation.PaymentMethod == "Paypal")
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
					var result = StripePayments.StripePaymentsForm(PersonalInformation, Pricing.Price.ToString());
					if (result.Status == "succeeded" && result.Paid)
					{
						TempData["purchaseFormlData"] = JsonConvert.SerializeObject(purchaseForm);
						return RedirectToAction("PurchaseQuote", "Quote");
					}
				}
				catch (Exception e)
				{
					TempData["StripePayment"] = "Stripe Payment has failed, please check your details and try again";
					return RedirectToAction("TFTPlacementBoost", "TFTBoosting");
				}

				//something went wrong
				return View();
			}
		}
	}
}