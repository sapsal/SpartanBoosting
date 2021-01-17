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
		public List<ChatModel> ChatModel { get; set; }
		public ApplicationUser CurrentUser { get; set; }
	}
}
