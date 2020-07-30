using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Models.Pricing
{
	public class SoloBoostPricing
	{
		public string CurrentDivision { get; set; }
		public string CurrentLP { get; set; }
		public string RequiredDivision { get; set; }
		public string GameboostPrice { get; set; }
		public string OurPrice { get; set; }
	}

	public class DuoBoostPricing
	{
		public string CurrentDivision { get; set; }
		public string CurrentLP { get; set; }
		public string RequiredDivision { get; set; }
		public string GameboostRegularPrice { get; set; }
		public string OurRegularPrice { get; set; }
		public string GameboostPremiumPrice { get; set; }
		public string OurPremiumPrice { get; set; }
	}
}
