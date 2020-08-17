﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SpartanBoosting.Utils;

namespace SpartanBoosting.Controllers
{
	public class TFTBoostingController : Controller
	{
		private PricingController PricingController { get; set; }
		private readonly ILogger<TFTBoostingController> _logger;
		public TFTBoostingController(ILogger<PricingController> logger)
		{
			this.PricingController = new PricingController(logger);
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
			JsonResult Pricing = PricingController.TFTSoloBoostPricing(BoostingModel);

			if (PersonalInformation.PaymentMethod == "Paypal")
			{
				var paypalResult = PayPalV2.createOrder(Pricing.Value.ToString());
				TempData["purchaseFormlData"] = JsonConvert.SerializeObject(Models.TFTBoostingModel.TFTBoostingModelToPurchaseForm(BoostingModel, Pricing.Value.ToString(), PersonalInformation, paypalResult));
				return Redirect(paypalResult.ApprovalURL);
			}
			else
			{
				try
				{
					var result = StripePayments.StripePaymentsForm(PersonalInformation, Pricing.Value.ToString());
					if (result.Status == "succeeded" && result.Paid)
					{
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
			JsonResult Pricing = PricingController.TFTPlacementBoostPricing(BoostingModel);

			if (PersonalInformation.PaymentMethod == "Paypal")
			{
				var paypalResult = PayPalV2.createOrder(Pricing.Value.ToString());
				TempData["purchaseFormlData"] = JsonConvert.SerializeObject(Models.TFTPlacementModel.TFTPlacementModelPurchaseForm(BoostingModel, Pricing.Value.ToString(), PersonalInformation, paypalResult));
				return Redirect(paypalResult.ApprovalURL);
			}
			else
			{
				try
				{
					var result = StripePayments.StripePaymentsForm(PersonalInformation, Pricing.Value.ToString());
					if (result.Status == "succeeded" && result.Paid)
					{
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