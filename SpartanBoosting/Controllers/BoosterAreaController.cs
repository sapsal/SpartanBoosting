using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpartanBoosting.Models;
using SpartanBoosting.Models.Repositorys;
using SpartanBoosting.Repositorys;
using SpartanBoosting.Repositorys.Interfaces;
using SpartanBoosting.ViewModel;
namespace SpartanBoosting.Controllers
{
	[Authorize(Roles = "Superuser,Booster")]
	public partial class BoosterAreaController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private IPurchaseOrderRepository PurchaseOrderRepository;
		private IChatModelRepository ChatModelRepository;
		private IUserRolesRepository UserRolesRepository;
		public BoosterAreaController(IPurchaseOrderRepository purchaseOrderRepository, IChatModelRepository chatModelRepository, UserManager<ApplicationUser> userManager, IUserRolesRepository userRolesRepository)
		{
			PurchaseOrderRepository = purchaseOrderRepository;
			ChatModelRepository = chatModelRepository;
			_userManager = userManager;
			UserRolesRepository = userRolesRepository;
		}

		public IActionResult Dashboard()
		{
			var user = _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value).Result;
			BoosterDashboardViewModel BoosterDashboardViewModel = new BoosterDashboardViewModel();
			BoosterDashboardViewModel.PurchaseForm = PurchaseOrderRepository.GetAllPurchaseOrdersByUser(user).ToList();
			return View(BoosterDashboardViewModel);
		}
		public IActionResult LolOrdersPanel()
		{
			BoosterDashboardViewModel BoosterDashboardViewModel = new BoosterDashboardViewModel();
			BoosterDashboardViewModel.PurchaseForm = PurchaseOrderRepository.GetAllPurchaseOrderAvailable().ToList();
			return View("LOL/LolOrdersPanel", BoosterDashboardViewModel);
		}
		
		public IActionResult TFTOrdersPanel()
		{
			BoosterDashboardViewModel BoosterDashboardViewModel = new BoosterDashboardViewModel();
			BoosterDashboardViewModel.PurchaseForm = PurchaseOrderRepository.GetAllPurchaseOrderAvailable().ToList();
			return View("LOL/TFTOrdersPanel", BoosterDashboardViewModel);
		}
	}
}