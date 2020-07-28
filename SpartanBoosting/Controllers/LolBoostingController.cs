using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SpartanBoosting.Controllers
{
    public class LolBoostingController : Controller
    {
        public IActionResult SoloBoosting()
        {
            Models.BoostingModel model = new Models.BoostingModel(); 
            return View(model);
        }

        [ValidateAntiForgeryToken()]
        [HttpPost]
        public JsonResult Create(Models.BoostingModel BoostingModel)
        {
            return Json(BoostingModel);
        }

        public IActionResult SoloBoostingSubmit(Models.BoostingModel Model)
        {
            Models.BoostingModel model = new Models.BoostingModel();
            return View(model);
        }
        public IActionResult DuoBoosting()
        {
            return View();
        }

        public IActionResult WinBoosting()
        {
            return View();
        }

        public IActionResult PlacementMatches()
        {
            return View();
        }
    }
}