using SpartanBoosting.Models.Pricing;
using SpartanBoosting.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Models
{
	public class CoachingModel
	{
		public List<CoachingPricesModel> CoachingPrices = new List<CoachingPricesModel> { new CoachingPricesModel { Price = "10.00", PackageType = "1 HOUR" }, new CoachingPricesModel { Price = "15.00", PackageType = "2 HOUR" }
		, new CoachingPricesModel { Price = "25.00", PackageType = "3 HOUR" }, new CoachingPricesModel { Price = "35.00", PackageType = "4 HOUR" }, new CoachingPricesModel { Price = "45.00", PackageType = "5 HOUR" }
		, new CoachingPricesModel { Price = "55.00", PackageType = "6 HOUR" }, new CoachingPricesModel { Price = "65.00", PackageType = "7 HOUR" }, new CoachingPricesModel { Price = "75.00", PackageType = "8 HOUR" }
		, new CoachingPricesModel { Price = "85.00", PackageType = "9 HOUR" }, new CoachingPricesModel { Price = "95.00", PackageType = "10 HOUR" }, new CoachingPricesModel { Price = "500.00", PackageType = "1 YEAR PACKAGE" }};
		[Key]
		public int Id { get; set; }
		public string SpecificChampions { get; set; }
		public string SpecificRolesTop { get; set; }
		public string SpecificRolesJungle { get; set; }
		public string SpecificRolesMiddle { get; set; }
		public string SpecificRolesADC { get; set; }
		public string SpecificRolesSupport { get; set; }
		public string Server { get; set; }
		public string CoachingPackage { get; set; }
		public string CurrentRank { get; set; }
		public static PurchaseForm CoachingModelToPurchaseForm(CoachingModel coachingModel, string pricing, PersonalInformation PersonalInformation, string ApprovalURL = null, string CaptureURL = null)
		{
			return new PurchaseForm
			{
				PurchaseType = Utils.PurchaseTypeEnum.PurchaseType.Coaching,
				CoachingModel = coachingModel,
				Pricing = pricing,
				PersonalInformation = PersonalInformation,
				PayPalApproval = ApprovalURL,
				PayPalCapture = CaptureURL
			};
		}
	}
	public class CoachingPricesModel
	{
		[Key]
		public int Id { get; set; }
		public string Price { get; set; }
		public string PackageType { get; set; }
	}
}
