using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Extensions
{
	public static class PricingExtensions
	{
		private static Dictionary<string, int> DiscountCodes = new Dictionary<string, int> { { "SiteLaunch15", 15 }, { "ByeS10", 20 } };
		public static double RoundUp(double input, int places)
		{
			double multiplier = Math.Pow(10, Convert.ToDouble(places));
			return Math.Ceiling(input * multiplier) / multiplier;
		}
		public static double BoosterPay(string Pricing)
		{
			decimal price = decimal.Parse(Pricing);
			price = (price / 100) * ObjectFactory.BoosterPercentage;
			return RoundUp((double)price, 2);
		}

		public static decimal PriceDiscount(string discountCode, decimal Pricing)
		{
			var discountCodeValue = DiscountCodes.Where(x => x.Key == discountCode).SingleOrDefault();
			if (!discountCodeValue.Equals(new KeyValuePair<string, int>()))
				return Pricing = Pricing - (Pricing * discountCodeValue.Value / 100);
			else
				return Pricing;
		}

		public static decimal PriceIncreaseLolNA(string Server, decimal Pricing)
		{
			if (Server == "Europe West" || Server == "Europe Nordic &amp; East" || Server == "Russia" || Server == "Turkey")
			{
				return Pricing;
			}
			else if (Server == "North America" || Server == "Oceania" || Server == "Latin America North" || Server == "Latin America South" || Server == "Brazil")
			{
				return Pricing = Pricing + (Pricing / 100) * 40;
			}
			return Pricing;
		}

		public static string DisplayLolTFTBoostJobDescription(SpartanBoosting.Models.Pricing.PurchaseForm purchaseForm)
		{
			switch (purchaseForm.PurchaseType)
			{
				case Utils.PurchaseTypeEnum.PurchaseType.SoloBoosting:
					return $"{purchaseForm.BoostingModel.YourCurrentLeague} {purchaseForm.BoostingModel.CurrentDivision} {purchaseForm.BoostingModel.CurrentLP} to {purchaseForm.BoostingModel.DesiredCurrentLeague} {purchaseForm.BoostingModel.DesiredCurrentDivision}";
				case Utils.PurchaseTypeEnum.PurchaseType.DuoBoosting:
					return $"{purchaseForm.BoostingModel.YourCurrentLeague} {purchaseForm.BoostingModel.CurrentDivision} {purchaseForm.BoostingModel.CurrentLP} to {purchaseForm.BoostingModel.DesiredCurrentLeague} {purchaseForm.BoostingModel.DesiredCurrentDivision}";
				case Utils.PurchaseTypeEnum.PurchaseType.WinBoosting:
					return $"{purchaseForm.WinBoostModel.YourCurrentLeague} {purchaseForm.WinBoostModel.CurrentDivision} With {purchaseForm.WinBoostModel.NumOfGames} Games";
				case Utils.PurchaseTypeEnum.PurchaseType.PlacementMatches:
					return $"{purchaseForm.PlacementMatchesModel.LastSeasonStanding} With {purchaseForm.PlacementMatchesModel.NumOfGames} Games";
				case Utils.PurchaseTypeEnum.PurchaseType.TFTPlacement:
					return $"{purchaseForm.TFTPlacementModel.LastSeasonStanding} With {purchaseForm.TFTPlacementModel.NumberOfGames} Games";
				case Utils.PurchaseTypeEnum.PurchaseType.TFTBoosting:
					return $"{purchaseForm.TFTBoostingModel.YourCurrentLeague} {purchaseForm.TFTBoostingModel.CurrentDivision} {purchaseForm.TFTBoostingModel.CurrentLP} to {purchaseForm.TFTBoostingModel.DesiredCurrentLeague} {purchaseForm.TFTBoostingModel.DesiredCurrentDivision}";
				case Utils.PurchaseTypeEnum.PurchaseType.Coaching:
					break;
				default:
					break;
			}
			return "";
		}
	}
}
