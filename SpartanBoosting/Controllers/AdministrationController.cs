using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpartanBoosting.Repositorys;
using SpartanBoosting.Utils.Enums;

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
        public IActionResult AssignUserBoosterRole(int Id)
        {
            UserRolesRepository.AddUserRoles((int)RolesEnum.Roles.Booster, Id);
            return Json(null);
        }
    }
}