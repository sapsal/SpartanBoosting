using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SpartanBoosting.Extensions;
using SpartanBoosting.Models;
using SpartanBoosting.Models.LeagueOfLegends_Models.Pricing;
using SpartanBoosting.Models.Pricing;
using SpartanBoosting.Repositorys.Interfaces;
using SpartanBoosting.Utils;
using Stripe;
using System;
using static SpartanBoosting.Utils.PurchaseTypeEnum;

namespace SpartanBoosting.Controllers
{
	public class LolBoostingController : Controller
	{
		private PricingController PricingController { get; set; }
		public LolBoostingController(ILogger<PricingController> logger, IDiscountModelRepository discountModelRepository)
		{
			this.PricingController = new PricingController(logger, discountModelRepository);
		}
		[ValidateAntiForgeryToken()]
		[HttpPost]
		public IActionResult CreateSolo(Models.BoostingModel BoostingModel, PersonalInformation PersonalInformation)
		{
			PricingResponse Pricing = JsonConvert.DeserializeObject<PricingResponse>(JsonConvert.SerializeObject(PricingController.SoloPricing(BoostingModel).Value));

			PurchaseForm purchaseForm = Models.BoostingModel.BoostingModelToPurchaseForm(BoostingModel, Pricing.Price.ToString(), PersonalInformation);
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
					return RedirectToAction("soloboosting", "lolboosting");
				}
				//something went wrong
				return View();
			}
		}

		[ValidateAntiForgeryToken()]
		[HttpPost]
		public IActionResult CreateDuo(Models.BoostingModel BoostingModel, Models.PersonalInformation PersonalInformation)
		{
			PricingResponse Pricing = JsonConvert.DeserializeObject<PricingResponse>(JsonConvert.SerializeObject(PricingController.DuoPricing(BoostingModel).Value));

			PurchaseForm purchaseForm = Models.BoostingModel.BoostingModelToPurchaseForm(BoostingModel, Pricing.Price.ToString(), PersonalInformation);
			purchaseForm.Discount = Pricing.DiscountModel;
			purchaseForm.PurchaseType = PurchaseType.DuoBoosting;
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
					return RedirectToAction("duoboosting", "lolboosting");
				}

				//something went wrong
				return View();
			}
		}

		[ValidateAntiForgeryToken()]
		[HttpPost]
		public IActionResult CreatePlacementMatches(Models.PlacementMatchesModel PlacementMatchesModel, Models.PersonalInformation PersonalInformation)
		{
			PricingResponse Pricing = JsonConvert.DeserializeObject<PricingResponse>(JsonConvert.SerializeObject(PricingController.PlacementBoostPricing(PlacementMatchesModel).Value));
			PurchaseForm purchaseForm = Models.PlacementMatchesModel.PlacementMatchesModelToPurchaseForm(PlacementMatchesModel, Pricing.Price.ToString(), PersonalInformation);
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
					return RedirectToAction("PlacementMatches", "lolboosting");
				}

				//something went wrong
				return View();
			}
		}

		[ValidateAntiForgeryToken()]
		[HttpPost]
		public IActionResult CreateWinBoost(Models.WinBoostModel WinBoostModel, Models.PersonalInformation PersonalInformation)
		{
			PricingResponse Pricing = JsonConvert.DeserializeObject<PricingResponse>(JsonConvert.SerializeObject(PricingController.WinBoostPricing(WinBoostModel).Value));
			PurchaseForm purchaseForm = Models.WinBoostModel.WinBoostModelToPurchaseForm(WinBoostModel, Pricing.Price.ToString(), PersonalInformation);
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
					return RedirectToAction("winboosting", "lolboosting");
				}

				//something went wrong
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