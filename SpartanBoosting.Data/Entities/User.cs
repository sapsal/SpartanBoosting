using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SpartanBoosting.Data.Entities
{
	public class User
	{
		[Key]
		public Int64 Id { get; set; }
		[Required]
		public String UserName { get; set; }
		[Required]
		public String Password { get; set; }
	}
}
