using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpartanBoosting.Models.Repositorys;
using SpartanBoosting.Repositorys;
using SpartanBoosting.Utils.Enums;

namespace SpartanBoosting.Controllers
{
    [Authorize(Roles = "Superuser")]
    public class AdministrationController : Controller
    {
        private IUserRolesRepository UserRolesRepository;
        private IPurchaseOrderRepository PurchaseOrderRepository;
        public AdministrationController(IUserRolesRepository userRolesRepository, IPurchaseOrderRepository purchaseOrderRepository)
        {
            UserRolesRepository = userRolesRepository;
            PurchaseOrderRepository = purchaseOrderRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AssignLolUserRoles()
        {
           var result =  UserRolesRepository.GetUsersWithRoles();
            return View("UserRolesLol/AssignLolUserRoles", result);
        }

        public IActionResult OrdersOverview()
        {
            var result = PurchaseOrderRepository.GetAllPurchaseOrder().ToList();
            return View("OrdersLol/OrdersOverview", result);
        }
        [HttpPost]
        public IActionResult AssignUserBoosterRole(int Id)
        {
            UserRolesRepository.AddUserRoles((int)RolesEnum.Roles.Booster, Id);
            return Json(null);
        }
    }
}