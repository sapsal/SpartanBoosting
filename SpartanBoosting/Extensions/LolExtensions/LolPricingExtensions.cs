using SpartanBoosting.Models;
using SpartanBoosting.Models.LeagueOfLegends_Models.Pricing;
using SpartanBoosting.Models.Pricing;
using SpartanBoosting.Models.Repositorys;
using SpartanBoosting.Repositorys.Interfaces;
using SpartanBoosting.ViewModel.Lol_ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Extensions
{
	public static class LolPricingExtensions
	{

		public static double RoundUp(double input, int places)
		{
			double multiplier = Math.Pow(10, Convert.ToDouble(places));
			return Math.Ceiling(input * multiplier) / multiplier;
		}
		public static double BoosterPay(PurchaseForm PurchaseForm)
		{
			string pricing = PurchaseForm.Pricing;
			string discountCode = string.Empty;
			switch (PurchaseForm.PurchaseType)
			{
				case Utils.PurchaseTypeEnum.PurchaseType.DuoBoosting:
				case Utils.PurchaseTypeEnum.PurchaseType.SoloBoosting:
					discountCode = PurchaseForm.BoostingModel.DiscountCode;
					break;
				case Utils.PurchaseTypeEnum.PurchaseType.WinBoosting:
					discountCode = PurchaseForm.WinBoostModel.Discount;
					break;
				case Utils.PurchaseTypeEnum.PurchaseType.PlacementMatches:
					discountCode = PurchaseForm.PlacementMatchesModel.Discount;
					break;
				case Utils.PurchaseTypeEnum.PurchaseType.TFTPlacement:
					discountCode = PurchaseForm.TFTPlacementModel.DiscountCode;
					break;
				case Utils.PurchaseTypeEnum.PurchaseType.TFTBoosting:
					discountCode = PurchaseForm.TFTBoostingModel.DiscountCode;
					break;
			}

			decimal price = decimal.Parse(pricing);

			if (PurchaseForm.Discount != null)
			{
				//80% if discount code is applied
				price = (price / 100) * (ObjectFactory.BoosterPercentage + 10);
			}
			else
			{
				price = (price / 100) * ObjectFactory.BoosterPercentage;
			}
			return RoundUp((double)price, 2);

		}

		public static decimal PriceIncreaseLolNA(string Server, decimal Pricing, int percentage)
		{
			if (Server == "Europe West" || Server == "Europe Nordic &amp; East" || Server == "Russia" || Server == "Turkey")
			{
				return Pricing;
			}
			else if (Server == "North America" || Server == "Oceania" || Server == "Latin America North" || Server == "Latin America South" || Server == "Brazil")
			{
				return Pricing = Pricing + (Pricing / 100) * percentage;
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

		public static LolActivityViewModel DisplayLolActivityViewModel(SpartanBoosting.Models.Pricing.PurchaseForm purchaseForm)
		{
			LolActivityViewModel LolActivityViewModel = new LolActivityViewModel();
			LolActivityViewModel.OrderNumber = $"#LOL-{purchaseForm.Id}";
			LolActivityViewModel.DaysAgo = (int)Math.Abs(Math.Round((DateTime.Now - purchaseForm.CreatedDate).TotalDays));
			switch (purchaseForm.PurchaseType)
			{
				case Utils.PurchaseTypeEnum.PurchaseType.SoloBoosting:
					LolActivityViewModel.RankUrl = $"solo";
					LolActivityViewModel.OrderTitle = "New Division Solo!";
					LolActivityViewModel.OrderInformation = $"{purchaseForm.BoostingModel.YourCurrentLeague} {purchaseForm.BoostingModel.CurrentDivision} {purchaseForm.BoostingModel.CurrentLP} to {purchaseForm.BoostingModel.DesiredCurrentLeague} {purchaseForm.BoostingModel.DesiredCurrentDivision}";
					break;
				case Utils.PurchaseTypeEnum.PurchaseType.DuoBoosting:
					LolActivityViewModel.RankUrl = $"duo";
					LolActivityViewModel.OrderTitle = "New Division Duo!";
					LolActivityViewModel.OrderInformation = $"{purchaseForm.BoostingModel.YourCurrentLeague} {purchaseForm.BoostingModel.CurrentDivision} {purchaseForm.BoostingModel.CurrentLP} to {purchaseForm.BoostingModel.DesiredCurrentLeague} {purchaseForm.BoostingModel.DesiredCurrentDivision}";
					break;
				case Utils.PurchaseTypeEnum.PurchaseType.WinBoosting:
					LolActivityViewModel.RankUrl = $"win";
					LolActivityViewModel.OrderTitle = $"New Win Boost {purchaseForm.WinBoostModel.TypeOfService}!";
					LolActivityViewModel.OrderInformation = $"{purchaseForm.WinBoostModel.YourCurrentLeague} {purchaseForm.WinBoostModel.CurrentDivision} With {purchaseForm.WinBoostModel.NumOfGames} Games";
					break;
				case Utils.PurchaseTypeEnum.PurchaseType.PlacementMatches:
					LolActivityViewModel.RankUrl = $"placement";
					LolActivityViewModel.OrderTitle = $"New Placement {purchaseForm.PlacementMatchesModel.TypeOfService}!";
					LolActivityViewModel.OrderInformation = $"{purchaseForm.PlacementMatchesModel.LastSeasonStanding} With {purchaseForm.PlacementMatchesModel.NumOfGames} Games";
					break;
				case Utils.PurchaseTypeEnum.PurchaseType.TFTPlacement:
					LolActivityViewModel.RankUrl = $"placement";
					LolActivityViewModel.OrderTitle = $"New Placement {purchaseForm.PlacementMatchesModel.TypeOfService}!";
					LolActivityViewModel.OrderInformation = $"{purchaseForm.TFTPlacementModel.LastSeasonStanding} With {purchaseForm.TFTPlacementModel.NumberOfGames} Games";
					break;
				case Utils.PurchaseTypeEnum.PurchaseType.TFTBoosting:
					LolActivityViewModel.RankUrl = $"solo";
					LolActivityViewModel.OrderTitle = $"New TFT Boost Solo!";
					LolActivityViewModel.OrderInformation = $"{purchaseForm.TFTBoostingModel.YourCurrentLeague} {purchaseForm.TFTBoostingModel.CurrentDivision} {purchaseForm.TFTBoostingModel.CurrentLP} to {purchaseForm.TFTBoostingModel.DesiredCurrentLeague} {purchaseForm.TFTBoostingModel.DesiredCurrentDivision}";
					break;
				case Utils.PurchaseTypeEnum.PurchaseType.Coaching:
					break;
				default:
					break;
			}
			return LolActivityViewModel;
		}
	}

	public class LolDiscountExtensions
	{
		private readonly IDiscountModelRepository _DiscountModelRepository;
		private List<Models.DiscountModel> DiscountModel;
		public LolDiscountExtensions(IDiscountModelRepository discountModelRepository)
		{
			_DiscountModelRepository = discountModelRepository;
			DiscountModel = _DiscountModelRepository.GetDiscountModels();
		}
		public double RoundUp(double input, int places)
		{
			double multiplier = Math.Pow(10, Convert.ToDouble(places));
			return Math.Ceiling(input * multiplier) / multiplier;
		}
	
		public DiscountViewModel PriceDiscount(string discountCode, decimal Pricing)
		{
			var discountCodeValue = DiscountModel.Where(x => x.DiscountCode == discountCode).SingleOrDefault();
			if (discountCodeValue != null)
				return new DiscountViewModel { Price = Pricing - (Pricing * discountCodeValue.DiscountPercentage / 100), DicountPercentage = discountCodeValue.DiscountPercentage, DiscountId = discountCodeValue.Id };
			else
				return new DiscountViewModel { Price = Pricing };
		}
	}
}
