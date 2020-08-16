using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SpartanBoosting.Models.Repositorys;
using SpartanBoosting.ViewModel;
namespace SpartanBoosting.Controllers
{
    public class BoosterAreaController : Controller
    {
        private IPurchaseOrderRepository PurchaseOrderRepository;
        public BoosterAreaController(IPurchaseOrderRepository purchaseOrderRepository)
        {
            PurchaseOrderRepository = purchaseOrderRepository;
        }
        public IActionResult Dashboard()
        {
            BoosterDashboardViewModel BoosterDashboardViewModel = new BoosterDashboardViewModel();
            BoosterDashboardViewModel.PurchaseForm = PurchaseOrderRepository.GetAllPurchaseOrderAvailable().ToList();
            return View(BoosterDashboardViewModel);
        }
    }
}