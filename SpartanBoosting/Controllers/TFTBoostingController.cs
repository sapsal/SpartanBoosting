using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SpartanBoosting.Extensions;
using SpartanBoosting.Models.LeagueOfLegends_Models.Pricing;
using SpartanBoosting.Repositorys.Interfaces;
using SpartanBoosting.Utils;

namespace SpartanBoosting.Controllers
{
	public class TFTBoostingController : Controller
	{
		private PricingController PricingController { get; set; }
		private readonly ILogger<TFTBoostingController> _logger;
		private readonly LolDiscountExtensions LolDiscountExtensions;
		public TFTBoostingController(ILogger<PricingController> logger, IDiscountModelRepository discountModelRepository)
		{
			this.PricingController = new PricingController(logger, discountModelRepository);
		}
		public IActionResult TFTPlacementMatches()
		{
			return View();
		}
		public IActionResult TFTSoloBoost()
		{
			return View();
		}

		[ValidateAntiForgeryToken()]
		[HttpPost]
		public IActionResult CreateTFTSoloBoost(Models.TFTBoostingModel BoostingModel, Models.PersonalInformation PersonalInformation)
		{
			PricingResponse Pricing = JsonConvert.DeserializeObject<PricingResponse>(JsonConvert.SerializeObject(PricingController.TFTSoloBoostPricing(BoostingModel).Value));

			if (PersonalInformation.PaymentMethod == "Paypal")
			{
				var paypalResult = PayPalV2.createOrder(Pricing.Price.ToString());
				TempData["purchaseFormlData"] = JsonConvert.SerializeObject(Models.TFTBoostingModel.TFTBoostingModelToPurchaseForm(BoostingModel, Pricing.Price.ToString(), PersonalInformation, paypalResult.ApprovalURL , paypalResult.CaptureURL));
				return Redirect(paypalResult.ApprovalURL);
			}
			else
			{
				try
				{
					var result = StripePayments.StripePaymentsForm(PersonalInformation, Pricing.Price.ToString());
					if (result.Status == "succeeded" && result.Paid)
					{
						TempData["purchaseFormlData"] = JsonConvert.SerializeObject(Models.TFTBoostingModel.TFTBoostingModelToPurchaseForm(BoostingModel, Pricing.Price.ToString(), PersonalInformation));

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
			PricingResponse Pricing = JsonConvert.DeserializeObject<PricingResponse>(JsonConvert.SerializeObject(PricingController.TFTPlacementBoostPricing(BoostingModel).Value));

			if (PersonalInformation.PaymentMethod == "Paypal")
			{
				var paypalResult = PayPalV2.createOrder(Pricing.Price.ToString());
				TempData["purchaseFormlData"] = JsonConvert.SerializeObject(Models.TFTPlacementModel.TFTPlacementModelPurchaseForm(BoostingModel, Pricing.Price.ToString(), PersonalInformation, paypalResult.ApprovalURL , paypalResult.CaptureURL));
				return Redirect(paypalResult.ApprovalURL);
			}
			else
			{
				try
				{
					var result = StripePayments.StripePaymentsForm(PersonalInformation, Pricing.Price.ToString());
					if (result.Status == "succeeded" && result.Paid)
					{
						TempData["purchaseFormlData"] = JsonConvert.SerializeObject(Models.TFTPlacementModel.TFTPlacementModelPurchaseForm(BoostingModel, Pricing.Price.ToString(), PersonalInformation));
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