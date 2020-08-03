using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpartanBoosting.Utils;

namespace SpartanBoosting.Controllers
{
    public class TFTBoostingController : Controller
    {
        private PricingController PricingController { get; set; }
        public TFTBoostingController()
        {
            this.PricingController = new PricingController();
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
                return Redirect(PayPalPayment.CreatePaymentRequest(Pricing.Value.ToString()));
            }
            else
            {
                var result = StripePayments.StripePaymentsForm(PersonalInformation, Pricing.Value.ToString());
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
                return Redirect(PayPalPayment.CreatePaymentRequest(Pricing.Value.ToString()));
            }
            else
            {
                var result = StripePayments.StripePaymentsForm(PersonalInformation, Pricing.Value.ToString());
                return View();
            }
        }
    }
}