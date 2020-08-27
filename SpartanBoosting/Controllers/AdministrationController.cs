using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpartanBoosting.Repositorys;

namespace SpartanBoosting.Controllers
{
    [Authorize(Roles = "Superuser")]
    public class AdministrationController : Controller
    {
        private IUserRolesRepository UserRolesRepository;
        public AdministrationController(IUserRolesRepository userRolesRepository)
        {
            UserRolesRepository = userRolesRepository;
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
        [HttpPost]
        public IActionResult AssignUserRole(int Id)
        {

            return Json(null);
        }
    }
}