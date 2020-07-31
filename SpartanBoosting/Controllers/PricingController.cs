using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpartanBoosting.Models.Pricing;

namespace SpartanBoosting.Controllers
{
	public class PricingController : Controller
	{
		[HttpPost]
		public ActionResult SoloPricing(Models.BoostingModel Model)
		{
			SoloBoostPricing result = ObjectFactory.SoloBoostPricing.Where(x => x.CurrentDivision == $"{Model.YourCurrentLeague} {Model.CurrentDivision}" && x.CurrentLP == Model.CurrentLP.Replace("LP ", "")
			&& x.RequiredDivision == $"{Model.DesiredCurrentLeague} {Model.DesiredCurrentDivision}").FirstOrDefault();
			if (result == null)
				return Json(0);
			else
			{
				decimal price = decimal.Parse(result.OurPrice);
				if (Model.SpecificRolesADC != "false" || Model.SpecificRolesTop != "false" || Model.SpecificRolesJungle != "false" || Model.SpecificRolesMiddle != "false" || Model.SpecificRolesSupport != "false")
				{
					// Add 15%
					price = price + (price / 100) * 15;
				}
				if (Model.SpecificChampions != null)
				{
					price = price + (price / 100) * 15;
				}
				price = (System.Math.Ceiling(price * 100) / 100);
				return Json(price);
			}
		}

		[HttpPost]
		public ActionResult DuoPricing(Models.BoostingModel Model)
		{
			decimal price;
			DuoBoostPricing result = ObjectFactory.DuoBoostPricing.Where(x => x.CurrentDivision == $"{Model.YourCurrentLeague} {Model.CurrentDivision}" && x.CurrentLP == Model.CurrentLP.Replace("LP ", "")
			&& x.RequiredDivision == $"{Model.DesiredCurrentLeague} {Model.DesiredCurrentDivision}").FirstOrDefault();
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

				price = (System.Math.Ceiling(price * 100) / 100);
				return Json(price);
			}
		}

		[HttpPost]
		public ActionResult WinBoostPricing(Models.WinBoostModel Model)
		{
			decimal price;
			string premiumOrRegular = Model.TypeOfDuoPremium != "false" ? "Premium" : "Regular";
			string lastSeason = Model.TypeOfService == "Duo" ? $"{Model.YourCurrentLeague} {Model.CurrentDivision} ({Model.TypeOfService}) ({premiumOrRegular})"
			: $"{Model.YourCurrentLeague} {Model.CurrentDivision} ({Model.TypeOfService})";
			WinBoostPricing result = ObjectFactory.WinBoostPricing.Where(x => x.LastSeasonStanding == lastSeason && x.NumberOfGames == Model.NumOfGames).FirstOrDefault();
			if (result == null)
				return Json(1.50);
			else
			{
				price = (System.Math.Ceiling(decimal.Parse(result.OurPrice) * 100) / 100);
				return Json(price);
			}
		}

	}
}