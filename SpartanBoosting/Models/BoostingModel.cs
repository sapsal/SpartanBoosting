using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Models
{
	public class BoostingModel
	{
		public string YourCurrentLeague { get; set; }
		public string CurrentLP { get; set; }
		public string CurrentDivision { get; set; }
		public string DesiredCurrentLeague { get; set; }
		public string DesiredCurrentDivision { get; set; }
		public string Server { get; set; }
		public string TypeOfQueue { get; set; }
		public string SpecificRoles { get; set; }
		public string SpecificChampions { get; set; }
		public bool VPN { get; set; }
		public string DiscountCode { get; set; }
	}
}
