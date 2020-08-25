using Microsoft.AspNetCore.Identity;
using SpartanBoosting.BuisnessLogic.Models.AggregateDatabaseModels;
using SpartanBoosting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Repositorys
{
	public interface IUserRolesRepository
	{
		List<IdentityUserRole<long>> GetUserRoles();
		List<UsersWithRolesAggregate> GetUsersWithRoles();
	}
}
