using Microsoft.AspNetCore.Mvc;
using SpartanBoosting.Utils;
using Stripe;

namespace SpartanBoosting.Controllers
{
	public class LolBoostingController : Controller
	{
		private PricingController PricingController { get; set; }
		public LolBoostingController()
		{
			this.PricingController = new PricingController();
		}
		[ValidateAntiForgeryToken()]
		[HttpPost]
		public IActionResult CreateSolo(Models.BoostingModel BoostingModel, Models.PersonalInformation PersonalInformation)
		{
			JsonResult Pricing = PricingController.SoloPricing(BoostingModel);
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
		public IActionResult CreateDuo(Models.BoostingModel BoostingModel, Models.PersonalInformation PersonalInformation)
		{
			JsonResult Pricing = PricingController.DuoPricing(BoostingModel);

			if (PersonalInformation.PaymentMethod == "Paypal")
			{
				return Redirect(PayPalPayment.CreatePaymentRequest(Pricing.Value.ToString()));
			}
			else
			{
				StripePayments.StripePaymentsForm(PersonalInformation, Pricing.Value.ToString());
				return View();
			}
		}

		[ValidateAntiForgeryToken()]
		[HttpPost]
		public IActionResult CreatePlacementMatches(Models.PlacementMatchesModel PlacementMatchesModel, Models.PersonalInformation PersonalInformation)
		{
			JsonResult Pricing = PricingController.PlacementBoostPricing(PlacementMatchesModel);
			if (PersonalInformation.PaymentMethod == "Paypal")
			{
				return Redirect(PayPalPayment.CreatePaymentRequest(Pricing.Value.ToString()));
			}
			else
			{
				StripePayments.StripePaymentsForm(PersonalInformation, Pricing.Value.ToString());
				return View();
			}
		}

		[ValidateAntiForgeryToken()]
		[HttpPost]
		public IActionResult CreateWinBoost(Models.WinBoostModel WinBoostModel, Models.PersonalInformation PersonalInformation)
		{
			JsonResult Pricing = PricingController.WinBoostPricing(WinBoostModel);
			if (PersonalInformation.PaymentMethod == "Paypal")
			{
				return Redirect(PayPalPayment.CreatePaymentRequest(Pricing.Value.ToString()));
			}
			else
			{
				StripePayments.StripePaymentsForm(PersonalInformation, Pricing.Value.ToString());
				return View();
			}
		}

		public IActionResult SoloBoosting()
		{
			Models.BoostingModel model = new Models.BoostingModel();

			return View(model);
		}

		public IActionResult DuoBoosting()
		{
			Models.BoostingModel model = new Models.BoostingModel();
			return View(model);
		}

		public IActionResult WinBoosting()
		{
			Models.WinBoostModel model = new Models.WinBoostModel();
			return View(model);
		}

		public IActionResult PlacementMatches()
		{
			Models.PlacementMatchesModel model = new Models.PlacementMatchesModel();
			return View(model);
		}

		public ActionResult DisplayInformationAndPayment()
		{
			return PartialView("~/Views/Partials/InformationAndPaymentPartial.cshtml");
		}
	}
}