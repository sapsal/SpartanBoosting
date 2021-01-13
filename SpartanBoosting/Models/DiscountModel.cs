using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Models
{
	public class DiscountModel
	{
		[Key]
		public int Id { get; set; }
		public string DiscountCode { get; set; }
		public bool SingleUse { get; set; }
		public int DiscountPercentage { get; set; }
	}
}
