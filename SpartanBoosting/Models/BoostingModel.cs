using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
	}
}
