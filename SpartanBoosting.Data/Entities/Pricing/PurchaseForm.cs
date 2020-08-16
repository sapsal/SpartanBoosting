using SpartanBoosting.Data.Utils;
using System.ComponentModel.DataAnnotations;
namespace SpartanBoosting.Data.Models.Pricing
{
	public class PurchaseForm
	{
		[Key]
		public int Id { get; set; }
		public CoachingModel CoachingModel { get; set; }
		public BoostingModel BoostingModel { get; set; }
		public PlacementMatchesModel PlacementMatchesModel { get; set; }
		public WinBoostModel WinBoostModel { get; set; }
		public PersonalInformation PersonalInformation { get; set; }
		public TFTPlacementModel TFTPlacementModel { get; set; }
		public TFTBoostingModel TFTBoostingModel { get; set; }
		public string Pricing { get; set; }
		public bool JobAvailable { get; set; } = true;
		public PurchaseTypeEnum.PurchaseType PurchaseType { get; set; }
	}
}
