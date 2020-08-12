using SpartanBoosting.Models.Pricing;
using Stripe;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static SpartanBoosting.Utils.PurchaseTypeEnum;

namespace SpartanBoosting.Models
{
	public class TFTPlacementModel
	{
		[Key]
		public int Id { get; set; }
		public string LastSeasonStanding { get; set; }
		public string Server { get; set; }
		public string NumberOfGames { get; set; }
		public string DiscountCode { get; set; }
		public static PurchaseForm TFTPlacementModelPurchaseForm(TFTPlacementModel TFTPlacementModel, string pricing, PersonalInformation PersonalInformation)
		{
			return new PurchaseForm
			{
				TFTPlacementModel = TFTPlacementModel,
				PurchaseType = PurchaseType.TFTPlacement,
				Pricing = pricing, 
				PersonalInformation = PersonalInformation
			};
		}
	}
	public class TFTBoostingModel
	{
		[Key]
		public int Id { get; set; }
		public string YourCurrentLeague { get; set; }
		public string DesiredCurrentLeague { get; set; }
		public string CurrentDivision { get; set; }
		public string DesiredCurrentDivision { get; set; }
		public string CurrentLP { get; set; }
		public string Server { get; set; }
		public string DiscountCode { get; set; }
		public static PurchaseForm TFTBoostingModelToPurchaseForm(TFTBoostingModel winBoostModel, string pricing, PersonalInformation PersonalInformation)
		{
			return new PurchaseForm
			{
				TFTBoostingModel = winBoostModel,
				PurchaseType = PurchaseType.TFTPlacement,
				Pricing = pricing,
				PersonalInformation = PersonalInformation
			};
		}
	}
}
