using System;
using System.Collections.Generic;
using System.Text;

namespace SpartanBoosting.BuisnessLogic.Models.AggregateDatabaseModels
{
	public class UsersWithRolesAggregate
	{
		public long? UserId { get; set; }
		public long? RoleId { get; set; }
		public string Role { get; set; }
		public string UserName { get; set; }
	}
}
