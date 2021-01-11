using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SpartanBoosting.Utils;
namespace SpartanBoosting.Models.Pricing
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
		public ApplicationUser BoosterAssignedTo { get; set; }
		public bool BoosterCompletionConfirmed { get; set; }
		public bool CustomerCompletionConfirmed { get; set; }
		public bool AdminCompletionConfirmed { get; set; }
		public string Pricing { get; set; }
		public string BoosterPricing { get; set; }
		public bool JobAvailable { get; set; } = true;
		public string PayPalApproval { get; set; }
		public string PayPalCapture{ get; set; }
		public PurchaseTypeEnum.PurchaseType PurchaseType { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
