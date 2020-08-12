using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpartanBoosting.Utils;
namespace SpartanBoosting.Models.Pricing
{
	public class PurchaseForm
	{
		public CoachingModel CoachingModel { get; set; }
		public BoostingModel BoostingModel { get; set; }
		public PlacementMatchesModel PlacementMatchesModel { get; set; }
		public WinBoostModel WinBoostModel { get; set; }
		public PersonalInformation PersonalInformation { get; set; }
		public TFTPlacementModel TFTPlacementModel { get; set; }
		public TFTBoostingModel TFTBoostingModel { get; set; }
		public string Pricing { get; set; }

		public PurchaseTypeEnum.PurchaseType PurchaseType { get; set; }
	}
}
