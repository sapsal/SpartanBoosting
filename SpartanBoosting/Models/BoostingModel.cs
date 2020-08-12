﻿using SpartanBoosting.Models.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SpartanBoosting.Utils.PurchaseTypeEnum;

namespace SpartanBoosting.Models
{
	public class BoostingModel
	{
		public string YourCurrentLeague { get; set; }
		public string DesiredCurrentLeague { get; set; }
		public string CurrentDivision { get; set; }
		public string DesiredCurrentDivision { get; set; }
		public string CurrentLP { get; set; }
		public string Server { get; set; }
		public string TypeOfQueue { get; set; }
		public string SpecificRolesTop { get; set; }
		public string SpecificRolesJungle { get; set; }
		public string SpecificRolesMiddle { get; set; }
		public string SpecificRolesADC { get; set; }
		public string SpecificRolesSupport { get; set; }
		public string TypeOfDuoRegular { get; set; }
		public string TypeOfDuoPremium { get; set; }
		public string SpecificChampions { get; set; }
		public bool VPN { get; set; }
		public string DiscountCode { get; set; }
		public static PurchaseForm BoostingModelToPurchaseForm(BoostingModel boostingModel, string pricing, PersonalInformation PersonalInformation)
		{
			return new PurchaseForm
			{
				BoostingModel = boostingModel,
				Pricing = pricing,
				PurchaseType = PurchaseType.SoloBoosting,
				PersonalInformation = PersonalInformation
			};
		}
	}

	public class PlacementMatchesModel
	{
		public string LastSeasonStanding { get; set; }
		public string Server { get; set; }
		public string TypeOfQueue { get; set; }
		public string TypeOfService { get; set; }
		public string TypeOfDuoRegular { get; set; }
		public string TypeOfDuoPremium { get; set; }
		public string NumOfGames { get; set; }
		public string Discount { get; set; }

		public static PurchaseForm PlacementMatchesModelToPurchaseForm(PlacementMatchesModel placementMatchesModel, string pricing, PersonalInformation PersonalInformation)
		{
			return new PurchaseForm
			{
				PlacementMatchesModel = placementMatchesModel,
				PurchaseType = PurchaseType.PlacementMatches,
				Pricing = pricing,
				PersonalInformation = PersonalInformation
			};
		}
	}

	public class WinBoostModel
	{
		public string YourCurrentLeague { get; set; }
		public string CurrentDivision { get; set; }
		public string Server { get; set; }
		public string TypeOfService { get; set; }
		public string TypeOfQueue { get; set; }
		public string TypeOfDuoRegular { get; set; }
		public string TypeOfDuoPremium { get; set; }
		public string Discount { get; set; }

		public string NumOfGames { get; set; }

		public static PurchaseForm WinBoostModelToPurchaseForm(WinBoostModel winBoostModel, string pricing, PersonalInformation PersonalInformation)
		{
			return new PurchaseForm
			{
				WinBoostModel = winBoostModel,
				PurchaseType = PurchaseType.WinBoosting,
				Pricing = pricing,
				PersonalInformation = PersonalInformation
			};
		}
	}

	public class PersonalInformation
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Discord { get; set; }
		public string PaymentMethod { get; set; }
		public string stripeToken { get; set; }
	}
}
