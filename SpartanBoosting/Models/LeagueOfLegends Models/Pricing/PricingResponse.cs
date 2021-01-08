using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Models.LeagueOfLegends_Models.Pricing
{
	public class PricingResponse
	{
		public bool success { get; set; }
		public string Discount { get; set; }
		public string Price { get; set; }
	}
}
