using SpartanBoosting.Models;
using SpartanBoosting.Models.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.ViewModel
{
	public class BoosterDashboardViewModel
	{
		public ApplicationUser Booster { get; set; }
		public List<PurchaseForm> PurchaseForm { get; set; }
	}
}
