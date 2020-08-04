using SpartanBoosting.Models.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SpartanBoosting.Utils.PurchaseTypeEnum;

namespace SpartanBoosting.Models
{
	public class TFTPlacementModel
	{
		public string LastSeasonStanding { get; set; }
		public string Server { get; set; }
		public string NumberOfGames { get; set; }
		public string DiscountCode { get; set; }
		public static PurchaseForm TFTPlacementModelPurchaseForm(TFTPlacementModel TFTPlacementModel, string pricing)
		{
			return new PurchaseForm
			{
				TFTPlacementModel = TFTPlacementModel,
				PurchaseType = PurchaseType.TFTPlacement
			};
		}
	}
	public class TFTBoostingModel
	{
		public string YourCurrentLeague { get; set; }
		public string DesiredCurrentLeague { get; set; }
		public string CurrentDivision { get; set; }
		public string DesiredCurrentDivision { get; set; }
		public string CurrentLP { get; set; }
		public string Server { get; set; }
		public string DiscountCode { get; set; }
		public static PurchaseForm TFTBoostingModelToPurchaseForm(TFTBoostingModel winBoostModel, string pricing)
		{
			return new PurchaseForm
			{
				TFTBoostingModel = winBoostModel,
				PurchaseType = PurchaseType.TFTPlacement
			};
		}
	}
}
