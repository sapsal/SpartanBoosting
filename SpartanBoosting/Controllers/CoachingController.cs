﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SpartanBoosting.Utils;

namespace SpartanBoosting.Controllers
{
	public class CoachingController : Controller
	{
		public IActionResult Coaching()
		{
			return View();
		}
		[ValidateAntiForgeryToken()]
		[HttpPost]
		public IActionResult CreateCoaching(Models.CoachingModel CoachingModel, Models.PersonalInformation PersonalInformation)
		{
			var Pricing = CoachingModel.CoachingPrices[int.Parse(CoachingModel.CoachingPackage) - 1].Price;

			if (PersonalInformation.PaymentMethod == "Paypal")
			{
				var paypalResult = PayPalV2.createOrder(Pricing);
				TempData["purchaseFormlData"] = JsonConvert.SerializeObject(Models.CoachingModel.CoachingModelToPurchaseForm(CoachingModel, Pricing, PersonalInformation, paypalResult.ApprovalURL , paypalResult.CaptureURL));
				return Redirect(paypalResult.ApprovalURL);
			}
			else
			{
				try
				{
					var result = StripePayments.StripePaymentsForm(PersonalInformation, Pricing);
					if (result.Status == "succeeded" && result.Paid)
					{
						TempData["purchaseFormlData"] = JsonConvert.SerializeObject(Models.CoachingModel.CoachingModelToPurchaseForm(CoachingModel, Pricing, PersonalInformation));
						return RedirectToAction("PurchaseQuote", "Quote");
					}
				}
				catch (Exception e)
				{
					TempData["StripePayment"] = "Stripe Payment has failed, please check your details and try again";
					return RedirectToAction("Coaching", "Coaching");
				}

				//something went wrong
				return View();
			}
		}
	}
}