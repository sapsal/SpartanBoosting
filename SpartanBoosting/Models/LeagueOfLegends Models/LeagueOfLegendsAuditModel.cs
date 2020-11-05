using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Models.LeagueOfLegends_Models
{
	public class LeagueOfLegendsAuditModel
	{
		[Key]
		public int Id { get; set; }
		public ApplicationUser User { get; set; }
		public string Action { get; set; }
		public DateTime DateTime { get; set; }
	}
}
