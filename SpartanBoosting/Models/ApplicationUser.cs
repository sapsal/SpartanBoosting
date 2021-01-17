using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SpartanBoosting.Models
{
	// Add profile data for application users by adding properties to the ApplicationUser class
	public class ApplicationUser : IdentityUser<long>
	{
		public decimal Balance { get; set; }
		public string DiscordId { get; set; }
		public byte MaxAssignedBoostsAllowed { get; set; }
	}
}
