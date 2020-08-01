using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Models
{
	public class TFTPlacementModel
	{
		public string LastSeasonStanding { get; set; }
		public string Server { get; set; }
		public string NumberOfGames { get; set; }
		public string DiscountCode { get; set; }
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
	}
}
