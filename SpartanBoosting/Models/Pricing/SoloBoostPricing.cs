using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Models.Pricing
{
	public class SoloBoostPricing
	{
		[Key]
		public int Id { get; set; }
		public string CurrentDivision { get; set; }
		public string CurrentLP { get; set; }
		public string RequiredDivision { get; set; }
		public string GameboostPrice { get; set; }
		public string OurPrice { get; set; }
	}

	public class DuoBoostPricing
	{
		[Key]
		public int Id { get; set; }
		public string CurrentDivision { get; set; }
		public string CurrentLP { get; set; }
		public string RequiredDivision { get; set; }
		public string GameboostRegularPrice { get; set; }
		public string OurRegularPrice { get; set; }
		public string GameboostPremiumPrice { get; set; }
		public string OurPremiumPrice { get; set; }
	}
	public class WinBoostPricing {
		[Key]
		public int Id { get; set; }
		public string LastSeasonStanding { get; set; }
		public string NumberOfGames { get; set; }
		public string GameboostPrice { get; set; }
		public string OurPrice { get; set; }
	}

	public class TFTSoloBoostPricing {
		[Key]
		public int Id { get; set; }
		public string CurrentDivision { get; set; }
		public string CurrentLP { get; set; }
		public string RequiredDivision { get; set; }
		public string GameboostRegularPrice { get; set; }
		public string OurRegularPrice { get; set; }
	}
}
