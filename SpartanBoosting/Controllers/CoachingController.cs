using System;
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
			var Pricing = CoachingModel.CoachingPrices[int.Parse(CoachingModel.CoachingPackage)-1].Price;
			//JsonResult Pricing = PricingController.SoloPricing(BoostingModel);
			TempData["purchaseFormlData"] = JsonConvert.SerializeObject(Models.CoachingModel.CoachingModelToPurchaseForm(CoachingModel, Pricing));

			if (PersonalInformation.PaymentMethod == "Paypal")
			{
				return Redirect(PayPalPayment.CreatePaymentRequest(Pricing));
			}
			else
			{
				var result = StripePayments.StripePaymentsForm(PersonalInformation, Pricing);
				if (result.Status == "succeeded" && result.Paid)
				{
					return RedirectToAction("PurchaseQuote", "Quote");
				}

				//something went wrong
				return View();
			}
		}
	}
}