using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Models.Adhoc
{
	public class ContactUsModel
	{
		[Key]
		public int Id { get; set; }
		public string YourName { get; set; }
		public string YourEmail { get; set; }
		public string Message { get; set; }
	}
}
