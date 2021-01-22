using SpartanBoosting.Models;
using SpartanBoosting.Models.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.ViewModel
{
	public class LolOrderDetailsViewModel
	{
		public PurchaseForm PurchaseForm { get; set; }
		public string StartDivisionImage { get; set; }
		public string DesiredDivisionImage { get; set; }
		public string DivisionBoost { get; set; }
		public string Region { get; set; }
		public string Queue { get; set; }
		public string DuoType { get; set; }
		public string ServiceType { get; set; }
		public string Champions { get; set; }
		public string LP { get; set; }
		public string SpecificRoles { get; set; }
		public bool VPN { get; set; }
		public List<ChatModel> ChatModel { get; set; }
		public ApplicationUser CurrentUser { get; set; }
	}
}
