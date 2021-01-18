﻿using System;
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
		public JsonResult DuoPricing(Models.BoostingModel Model)
		{
			decimal price;
			string requiredDivision = Model.DesiredCurrentLeague == "Master" ? Model.DesiredCurrentLeague : $"{Model.DesiredCurrentLeague} {Model.DesiredCurrentDivision}";
			DuoBoostPricing result = ObjectFactory.DuoBoostPricing.Where(x => x.CurrentDivision == $"{Model.YourCurrentLeague} {Model.CurrentDivision}" && x.CurrentLP == Model.CurrentLP.Replace("LP ", "")
			&& x.RequiredDivision == requiredDivision).FirstOrDefault();
			if (result == null)
				return Json(0);
			else
			{

				if (Model.TypeOfDuoPremium != "false")
				{
					price = decimal.Parse(result.OurPremiumPrice);
				}
				else
				{
					price = decimal.Parse(result.OurRegularPrice);
				}

				price = LolPricingExtensions.PriceIncreaseLolNA(Model.Server, price, 60);
				var priceDiscountResult = LolDiscountExtensions.PriceDiscount(Model.DiscountCode, price);
				price = (System.Math.Ceiling(priceDiscountResult.Price * 100) / 100);
				return Json(new { success = true, Price = price, Discount = priceDiscountResult.DicountPercentage, DiscountModel = priceDiscountResult.Discount });
			}
		}

		[HttpPost]
		public JsonResult WinBoostPricing(Models.WinBoostModel Model)
		{
			decimal price;
			string premiumOrRegular = Model.TypeOfDuoPremium != "false" ? "Premium" : "Regular";
			string lastSeason = Model.TypeOfService == "Duo" ? $"{Model.YourCurrentLeague} {Model.CurrentDivision} ({Model.TypeOfService}) ({premiumOrRegular})"
			: $"{Model.YourCurrentLeague} {Model.CurrentDivision} ({Model.TypeOfService})";

			if (Model.YourCurrentLeague == "Master" || Model.YourCurrentLeague == "Grandmaster" || Model.YourCurrentLeague == "Challenger")
			{
				lastSeason = Model.TypeOfService == "Duo" ? $"{Model.YourCurrentLeague} ({Model.TypeOfService}) ({premiumOrRegular})"
				: $"{Model.YourCurrentLeague} ({Model.TypeOfService})";
			}

			WinBoostPricing result = ObjectFactory.WinBoostPricing.Where(x => x.LastSeasonStanding == lastSeason && x.NumberOfGames == Model.NumOfGames).FirstOrDefault();
			if (result == null)
				return Json(1.50);
			else
			{
				price = (System.Math.Ceiling(decimal.Parse(result.OurPrice) * 100) / 100);
				price = LolPricingExtensions.PriceIncreaseLolNA(Model.Server, price, 40);
				var priceDiscountResult = LolDiscountExtensions.PriceDiscount(Model.Discount, price);
				price = priceDiscountResult.Price;
				return Json(new { success = true, Price = price, Discount = priceDiscountResult.DicountPercentage, DiscountModel = priceDiscountResult.Discount });
			}
		}

		[HttpPost]
		public JsonResult PlacementBoostPricing(Models.PlacementMatchesModel Model)
		{
			decimal price;
			string premiumOrRegular = Model.TypeOfDuoPremium != "false" ? "Premium" : "Regular";
			string lastSeason = Model.TypeOfService == "Duo" ? $"{Model.LastSeasonStanding} ({Model.TypeOfService}) ({premiumOrRegular})"
			: $"{Model.LastSeasonStanding} ({Model.TypeOfService})";
			WinBoostPricing result = ObjectFactory.PlacementBoostPricing.Where(x => x.LastSeasonStanding == lastSeason && x.NumberOfGames == Model.NumOfGames).FirstOrDefault();
			if (result == null)
				return Json(1.50);
			else
			{
				price = (System.Math.Ceiling(decimal.Parse(result.OurPrice) * 100) / 100);
				price = LolPricingExtensions.PriceIncreaseLolNA(Model.Server, price, 40);
				var priceDiscountResult = LolDiscountExtensions.PriceDiscount(Model.Discount, price);
				price = priceDiscountResult.Price;
				return Json(new { success = true, Price = price, Discount = priceDiscountResult.DicountPercentage, DiscountModel = priceDiscountResult.Discount });
			}
		}

		[HttpPost]
		public JsonResult TFTSoloBoostPricing(Models.TFTBoostingModel Model)
		{
			string requiredDivision = Model.DesiredCurrentLeague == "Master" ? Model.DesiredCurrentLeague : $"{Model.DesiredCurrentLeague} {Model.DesiredCurrentDivision}";
			TFTSoloBoostPricing result = ObjectFactory.TFTSoloBoostPricing.Where(x => x.CurrentDivision == $"{Model.YourCurrentLeague} {Model.CurrentDivision}" && x.CurrentLP == Model.CurrentLP.Replace("LP ", "")
			&& x.RequiredDivision == requiredDivision).FirstOrDefault();
			if (result == null)
				return Json(0);
			else
			{
				decimal price = (System.Math.Ceiling(decimal.Parse(result.OurRegularPrice) * 100) / 100);
				var priceDiscountResult = LolDiscountExtensions.PriceDiscount(Model.DiscountCode, price);
				price = priceDiscountResult.Price;
				return Json(new { success = true, Price = price, Discount = priceDiscountResult.DicountPercentage, DiscountModel = priceDiscountResult.Discount });
			}

		}

		[HttpPost]
		public JsonResult TFTPlacementBoostPricing(Models.TFTPlacementModel Model)
		{
			WinBoostPricing result = ObjectFactory.TFTPlacementBoostPricing.Where(x => x.LastSeasonStanding == Model.LastSeasonStanding && x.NumberOfGames == Model.NumberOfGames).FirstOrDefault();
			if (result == null)
				return Json(0);
			else
			{
				decimal price = (System.Math.Ceiling(decimal.Parse(result.OurPrice) * 100) / 100);
				var priceDiscountResult = LolDiscountExtensions.PriceDiscount(Model.DiscountCode, price);
				price = priceDiscountResult.Price;
				return Json(new { success = true, Price = price, Discount = priceDiscountResult.DicountPercentage, DiscountModel = priceDiscountResult.Discount });
			}

		}
	}

}