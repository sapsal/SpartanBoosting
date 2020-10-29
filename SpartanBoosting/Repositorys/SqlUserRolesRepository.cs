using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SpartanBoosting.BuisnessLogic.Models.AggregateDatabaseModels;
using SpartanBoosting.Data;
using SpartanBoosting.Models.Pricing;
using SpartanBoosting.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Models.Repositorys
{
	public class SqlUserRolesRepository : IUserRolesRepository
	{
		private readonly ApplicationDbContext context;
		private readonly UserManager<ApplicationUser> _userManager;
		public SqlUserRolesRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
		{
			this.context = context;
			_userManager = userManager;
		}

		public List<IdentityUserRole<long>> GetUserRoles()
		{
			return context.UserRoles.ToList();
		}

		public ApplicationUser GetUserById(long id )
		{
			return context.Users.Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
		}

		public List<ApplicationUser> GetUsers() {
			return context.Users.ToList();
		}

		public EntityEntry<IdentityUserRole<long>> AddUserRoles(int roleId, int userId)
		{
			var result = context.UserRoles.Add(new IdentityUserRole<long>{ RoleId  = roleId , UserId = userId });
			context.SaveChanges();
			return result;
		}
		public List<UsersWithRolesAggregate> GetUsersWithRoles()
		{

			//outer join sql 
			var result = from users in context.Users
						 join userRoles in context.UserRoles on users.Id equals userRoles.UserId into gjj
						 from subpet2 in gjj.DefaultIfEmpty()
						 join roles in context.Roles on subpet2.RoleId equals roles.Id into gj
						 from subpet in gj.DefaultIfEmpty()
						 select new UsersWithRolesAggregate
						 {
							 UserId = users.Id,
							 UserName = users.UserName,
							 Role = subpet.Name,
							 RoleId = subpet.Id,
						 };
			return result.ToList();
		}
	}
}
