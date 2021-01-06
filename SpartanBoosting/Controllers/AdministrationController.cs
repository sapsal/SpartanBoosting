using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpartanBoosting.Extensions;
using SpartanBoosting.Models;
using SpartanBoosting.Models.Repositorys;
using SpartanBoosting.Repositorys;
using SpartanBoosting.Utils.Enums;

namespace SpartanBoosting.Controllers
{
	[Authorize(Roles = "Superuser")]
	public class AdministrationController : Controller
	{
		private IUserRepository UserRolesRepository;
		private IPurchaseOrderRepository PurchaseOrderRepository;
		private readonly UserManager<ApplicationUser> _userManager;
		public AdministrationController(IUserRepository userRolesRepository, IPurchaseOrderRepository purchaseOrderRepository, UserManager<ApplicationUser> userManager)
		{
			UserRolesRepository = userRolesRepository;
			PurchaseOrderRepository = purchaseOrderRepository;
			_userManager = userManager;
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult AssignLolUserRoles()
		{
			var result = UserRolesRepository.GetUsersWithRoles();
			return View("UserRolesLol/AssignLolUserRoles", result);
		}

		public IActionResult UpdateUserProfilesAdmin()
		{
			var result = UserRolesRepository.GetUsers();
			return View("Views/Administration/UserProfileInformation.cshtml", result);
		}

		public IActionResult OrdersOverview()
		{
			var result = PurchaseOrderRepository.GetAllUnCompletedPurchaseOrderWithBooster().ToList();
			return View("OrdersLol/OrdersOverview", result);
		}
		[HttpPost]
		public IActionResult AssignUserBoosterRole(int Id)
		{
			UserRolesRepository.AddUserRoles((int)RolesEnum.Roles.Booster, Id);
			return Json(null);
		}

		[HttpPost]
		public IActionResult UpdateUserProfileDiscordId(string discordId, int Id)
		{
			var user = _userManager.FindByIdAsync(Id.ToString()).Result;
			user.DiscordId = discordId;
			UserRolesRepository.UpdateUser(user);
			return Json(true);
		}


		[HttpPost]
		public IActionResult CancellBoosterJobSuperUser(int Id)
		{
			var result = PurchaseOrderRepository.GetPurchaseFormWithBooster(Id);
			result.BoosterCompletionConfirmed = false;
			result.BoosterAssignedTo = null;
			result.JobAvailable = true;
			PurchaseOrderRepository.Update(result);
			return Json(true);
		}
		[HttpPost]
		public IActionResult CompleteBoosterJobSuperUser(int Id)
		{
			var result = PurchaseOrderRepository.GetPurchaseFormModelsIncludedById(Id);
			result.AdminCompletionConfirmed = true;
			result.BoosterAssignedTo.Balance = result.BoosterAssignedTo.Balance + (decimal)LolPricingExtensions.BoosterPay(result);
			PurchaseOrderRepository.Update(result);
			return Json(true);
		}
	}
}