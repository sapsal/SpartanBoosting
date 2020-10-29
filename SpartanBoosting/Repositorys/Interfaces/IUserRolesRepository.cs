using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
		ApplicationUser GetUserById(long id);
		List<ApplicationUser> GetUsers();
		List<IdentityUserRole<long>> GetUserRoles();
		List<UsersWithRolesAggregate> GetUsersWithRoles();
		EntityEntry<IdentityUserRole<long>> AddUserRoles(int roleId, int userId);
	}
}
