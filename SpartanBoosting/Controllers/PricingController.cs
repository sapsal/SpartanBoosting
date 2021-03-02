using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpartanBoosting.Models;
using SpartanBoosting.Models.Pricing;
using Microsoft.AspNetCore.HttpOverrides;
using SpartanBoosting.Extensions;
using SpartanBoosting.Repositorys.Interfaces;

namespace SpartanBoosting.Controllers
{
	public class PricingController : Controller
	{
		private readonly ILogger<PricingController> _logger;
		private readonly LolDiscountExtensions LolDiscountExtensions;
		public PricingController(ILogger<PricingController> logger, IDiscountModelRepository discountModelRepository)
		{
			LolDiscountExtensions = new LolDiscountExtensions(discountModelRepository);
			_logger = logger;
		}

		[HttpPost]
		public JsonResult ApplyDiscountCode(string DiscountCode, string Price)
		{
			decimal price = decimal.Parse(Price.Replace(" €", ""));
			var priceDiscountResult = LolDiscountExtensions.PriceDiscount(DiscountCode, price);

			price = (System.Math.Ceiling(priceDiscountResult.Price * 100) / 100);
			return Json(new { success = true, Price = price, Discount = priceDiscountResult.DicountPercentage, DiscountModel = priceDiscountResult.Discount });
		}

		[HttpPost]
		public JsonResult SoloPricing(PurchaseForm Model)
		{
			string requiredDivision = Model.BoostingModel.DesiredCurrentLeague == "Master" ? Model.BoostingModel.DesiredCurrentLeague : $"{Model.BoostingModel.DesiredCurrentLeague} {Model.BoostingModel.DesiredCurrentDivision}";
			SoloBoostPricing result = ObjectFactory.SoloBoostPricing.Where(x => x.CurrentDivision == $"{Model.BoostingModel.YourCurrentLeague} {Model.BoostingModel.CurrentDivision}" && x.CurrentLP == Model.BoostingModel.CurrentLP.Replace("LP ", "")
			&& x.RequiredDivision == requiredDivision).FirstOrDefault();
			if (result == null)
				return Json(0);
			else
			{
				decimal price = decimal.Parse(result.OurPrice);
				if (Model.BoostingModel.SpecificRolesADC != "false" || Model.BoostingModel.SpecificRolesTop != "false" || Model.BoostingModel.SpecificRolesJungle != "false" || Model.BoostingModel.SpecificRolesMiddle != "false" || Model.BoostingModel.SpecificRolesSupport != "false")
				{
					// Add 15%
					price = price + (price / 100) * 15;
				}
				if (Model.BoostingModel.SpecificChampions != null)
				{
					price = price + (price / 100) * 15;
				}

				
				price = LolPricingExtensions.PriceIncreaseLolNA(Model.BoostingModel.Server, price, 20);
				var priceDiscountResult = LolDiscountExtensions.PriceDiscount(Model.BoostingModel.DiscountCode, price);
				price = (System.Math.Ceiling(priceDiscountResult.Price * 100) / 100);
				return Json(new { success = true, Price = price, Discount = priceDiscountResult.DicountPercentage, DiscountModel = priceDiscountResult.Discount });
			}
		}

		[HttpPost]
		public JsonResult DuoPricing(PurchaseForm Model)
		{
			decimal price;
			string requiredDivision = Model.BoostingModel.DesiredCurrentLeague == "Master" ? Model.BoostingModel.DesiredCurrentLeague : $"{Model.BoostingModel.DesiredCurrentLeague} {Model.BoostingModel.DesiredCurrentDivision}";
			DuoBoostPricing result = ObjectFactory.DuoBoostPricing.Where(x => x.CurrentDivision == $"{Model.BoostingModel.YourCurrentLeague} {Model.BoostingModel.CurrentDivision}" && x.CurrentLP == Model.BoostingModel.CurrentLP.Replace("LP ", "")
			&& x.RequiredDivision == requiredDivision).FirstOrDefault();
			if (result == null)
				return Json(0);
			else
			{

				if (Model.BoostingModel.TypeOfDuoPremium != "false")
				{
					price = decimal.Parse(result.OurPremiumPrice);
				}
				else
				{
					price = decimal.Parse(result.OurRegularPrice);
				}

				
				price = LolPricingExtensions.PriceIncreaseLolNA(Model.BoostingModel.Server, price, 60);
				var priceDiscountResult = LolDiscountExtensions.PriceDiscount(Model.BoostingModel.DiscountCode, price);
				price = (System.Math.Ceiling(priceDiscountResult.Price * 100) / 100);
				return Json(new { success = true, Price = price, Discount = priceDiscountResult.DicountPercentage, DiscountModel = priceDiscountResult.Discount });
			}
		}

		[HttpPost]
		public JsonResult WinBoostPricing(PurchaseForm Model)
		{
			decimal price;
			string premiumOrRegular = Model.WinBoostModel.TypeOfDuoPremium != "false" ? "Premium" : "Regular";
			string lastSeason = Model.WinBoostModel.TypeOfService == "Duo" ? $"{Model.WinBoostModel.YourCurrentLeague} {Model.WinBoostModel.CurrentDivision} ({Model.WinBoostModel.TypeOfService}) ({premiumOrRegular})"
			: $"{Model.WinBoostModel.YourCurrentLeague} {Model.WinBoostModel.CurrentDivision} ({Model.WinBoostModel.TypeOfService})";

			if (Model.WinBoostModel.YourCurrentLeague == "Master" || Model.WinBoostModel.YourCurrentLeague == "Grandmaster" || Model.WinBoostModel.YourCurrentLeague == "Challenger")
			{
				lastSeason = Model.WinBoostModel.TypeOfService == "Duo" ? $"{Model.WinBoostModel.YourCurrentLeague} ({Model.WinBoostModel.TypeOfService}) ({premiumOrRegular})"
				: $"{Model.WinBoostModel.YourCurrentLeague} ({Model.WinBoostModel.TypeOfService})";
			}

			WinBoostPricing result = ObjectFactory.WinBoostPricing.Where(x => x.LastSeasonStanding == lastSeason && x.NumberOfGames == Model.WinBoostModel.NumOfGames).FirstOrDefault();
			if (result == null)
				return Json(1.50);
			else
			{
				price = (System.Math.Ceiling(decimal.Parse(result.OurPrice) * 100) / 100);
				
				price = LolPricingExtensions.PriceIncreaseLolNA(Model.WinBoostModel.Server, price, 40);
				var priceDiscountResult = LolDiscountExtensions.PriceDiscount(Model.WinBoostModel.Discount, price);
				price = priceDiscountResult.Price;
				return Json(new { success = true, Price = price, Discount = priceDiscountResult.DicountPercentage, DiscountModel = priceDiscountResult.Discount });
			}
		}

		[HttpPost]
		public JsonResult PlacementBoostPricing(PurchaseForm Model)
		{
			decimal price;
			string premiumOrRegular = Model.PlacementMatchesModel.TypeOfDuoPremium != "false" ? "Premium" : "Regular";
			string lastSeason = Model.PlacementMatchesModel.TypeOfService == "Duo" ? $"{Model.PlacementMatchesModel.LastSeasonStanding} ({Model.PlacementMatchesModel.TypeOfService}) ({premiumOrRegular})"
			: $"{Model.PlacementMatchesModel.LastSeasonStanding} ({Model.PlacementMatchesModel.TypeOfService})";
			WinBoostPricing result = ObjectFactory.PlacementBoostPricing.Where(x => x.LastSeasonStanding == lastSeason && x.NumberOfGames == Model.PlacementMatchesModel.NumOfGames).FirstOrDefault();
			if (result == null)
				return Json(1.50);
			else
			{
				price = (System.Math.Ceiling(decimal.Parse(result.OurPrice) * 100) / 100);
				
				price = LolPricingExtensions.PriceIncreaseLolNA(Model.PlacementMatchesModel.Server, price, 40);
				var priceDiscountResult = LolDiscountExtensions.PriceDiscount(Model.PlacementMatchesModel.Discount, price);
				price = priceDiscountResult.Price;
				return Json(new { success = true, Price = price, Discount = priceDiscountResult.DicountPercentage, DiscountModel = priceDiscountResult.Discount });
			}
		}

		[HttpPost]
		public JsonResult TFTSoloBoostPricing(PurchaseForm Model)
		{
			string requiredDivision = Model.TFTBoostingModel.DesiredCurrentLeague == "Master" ? Model.TFTBoostingModel.DesiredCurrentLeague : $"{Model.TFTBoostingModel.DesiredCurrentLeague} {Model.TFTBoostingModel.DesiredCurrentDivision}";
			TFTSoloBoostPricing result = ObjectFactory.TFTSoloBoostPricing.Where(x => x.CurrentDivision == $"{Model.TFTBoostingModel.YourCurrentLeague} {Model.TFTBoostingModel.CurrentDivision}" && x.CurrentLP == Model.TFTBoostingModel.CurrentLP.Replace("LP ", "")
			&& x.RequiredDivision == requiredDivision).FirstOrDefault();
			if (result == null)
				return Json(0);
			else
			{
				decimal price = (System.Math.Ceiling(decimal.Parse(result.OurRegularPrice) * 100) / 100);
				var priceDiscountResult = LolDiscountExtensions.PriceDiscount(Model.TFTBoostingModel.DiscountCode, price);
				price = priceDiscountResult.Price;
				return Json(new { success = true, Price = price, Discount = priceDiscountResult.DicountPercentage, DiscountModel = priceDiscountResult.Discount });
			}

		}

		[HttpPost]
		public JsonResult TFTPlacementBoostPricing(PurchaseForm Model)
		{
			WinBoostPricing result = ObjectFactory.TFTPlacementBoostPricing.Where(x => x.LastSeasonStanding == Model.TFTPlacementModel.LastSeasonStanding && x.NumberOfGames == Model.TFTPlacementModel.NumberOfGames).FirstOrDefault();
			if (result == null)
				return Json(0);
			else
			{
				decimal price = (System.Math.Ceiling(decimal.Parse(result.OurPrice) * 100) / 100);
				var priceDiscountResult = LolDiscountExtensions.PriceDiscount(Model.TFTPlacementModel.DiscountCode, price);
				price = priceDiscountResult.Price;
				return Json(new { success = true, Price = price, Discount = priceDiscountResult.DicountPercentage, DiscountModel = priceDiscountResult.Discount });
			}

		}
	}

}