using Newtonsoft.Json;
using SpartanBoosting.Models;
using SpartanBoosting.Models.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartanBoosting.Extensions.LolExtensions
{
	public static class LolModelExtenstion
	{
		public static PurchaseForm AssignModel(PurchaseForm PurchaseForm, string Data)
		{
			switch (PurchaseForm.PurchaseType)
			{
				case Utils.PurchaseTypeEnum.PurchaseType.DuoBoosting:
				case Utils.PurchaseTypeEnum.PurchaseType.SoloBoosting:
					PurchaseForm.BoostingModel = JsonConvert.DeserializeObject<PurchaseForm>(Data).BoostingModel;
					break;
				case Utils.PurchaseTypeEnum.PurchaseType.WinBoosting:
					PurchaseForm.WinBoostModel = JsonConvert.DeserializeObject<PurchaseForm>(Data).WinBoostModel;
					break;
				case Utils.PurchaseTypeEnum.PurchaseType.PlacementMatches:
					PurchaseForm.PlacementMatchesModel = JsonConvert.DeserializeObject<PurchaseForm>(Data).PlacementMatchesModel;
					break;
				case Utils.PurchaseTypeEnum.PurchaseType.TFTPlacement:
					PurchaseForm.TFTPlacementModel = JsonConvert.DeserializeObject<PurchaseForm>(Data).TFTPlacementModel;
					break;
				case Utils.PurchaseTypeEnum.PurchaseType.TFTBoosting:
					PurchaseForm.TFTBoostingModel = JsonConvert.DeserializeObject<PurchaseForm>(Data).TFTBoostingModel;
					break;
			}
			return PurchaseForm;

		}
		public static string ChatModelTime(DateTime start, DateTime end)
		{
			TimeSpan span = (start - end);

			StringBuilder time = new StringBuilder();

			if (span.Days > 0)
				return $"{span.Days} days ago";
			else if (span.Days == 0)
				return $"{span.Hours} hours ago";
			else if (span.Days == 0 && span.Hours == 0)
				return $"{span.Minutes} minutes ago";
			else if (span.Days == 0 && span.Hours == 0 && span.Minutes == 0)
				return $"{span.Seconds} seconds ago";
			return "";
		}
	}
}
