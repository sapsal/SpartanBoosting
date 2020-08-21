using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpartanBoosting.Models;
using SpartanBoosting.Models.Repositorys;
using SpartanBoosting.ViewModel;
namespace SpartanBoosting.Controllers
{
	[Authorize(Roles = "Superuser")]
	public partial class BoosterAreaController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private IPurchaseOrderRepository PurchaseOrderRepository;
		public BoosterAreaController(IPurchaseOrderRepository purchaseOrderRepository, UserManager<ApplicationUser> userManager)
		{
			PurchaseOrderRepository = purchaseOrderRepository;
			_userManager = userManager;
		}

		public IActionResult Dashboard()
		{
			return View();
		}
		public IActionResult LolOrdersPanel()
		{
			BoosterDashboardViewModel BoosterDashboardViewModel = new BoosterDashboardViewModel();
			BoosterDashboardViewModel.PurchaseForm = PurchaseOrderRepository.GetAllPurchaseOrderAvailable().ToList();
			return View(BoosterDashboardViewModel);
		}
		public IActionResult TFTOrdersPanel()
		{
			BoosterDashboardViewModel BoosterDashboardViewModel = new BoosterDashboardViewModel();
			BoosterDashboardViewModel.PurchaseForm = PurchaseOrderRepository.GetAllPurchaseOrderAvailable().ToList();
			return View(BoosterDashboardViewModel);
		}
	}
}