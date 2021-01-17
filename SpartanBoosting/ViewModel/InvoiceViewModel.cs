using SpartanBoosting.Models.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SpartanBoosting.Utils.PurchaseTypeEnum;

namespace SpartanBoosting.ViewModel
{
	public class InvoiceViewModel
	{
		public PurchaseType PurchaseType { get; set; }
		public PurchaseForm PurchaseForm = new PurchaseForm(); //{ get; set; }
	}
}
