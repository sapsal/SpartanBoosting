using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Models.Pricing
{
	public class PurchaseForm
	{
			public string YourCurrentLeague { get; set; }
			public string DesiredCurrentLeague { get; set; }
			public string CurrentDivision { get; set; }
			public string DesiredCurrentDivision { get; set; }
			public string CurrentLP { get; set; }
			public string Server { get; set; }
			public string TypeOfQueue { get; set; }
			public bool VPN { get; set; }
			public string DiscountCode { get; set; }
			public string Price { get; set; }

			//placement
		public string LastSeasonStanding { get; set; }
		public string TypeOfService { get; set; }
		public string NumOfGames { get; set; }
	}
}
