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
        public JsonResult CreateSolo(Models.BoostingModel BoostingModel)
        {
            return Json(BoostingModel);
        }

        [ValidateAntiForgeryToken()]
        [HttpPost]
        public JsonResult CreateDuo(Models.BoostingModel BoostingModel)
        {
            return Json(BoostingModel);
        }

        [ValidateAntiForgeryToken()]
        [HttpPost]
        public JsonResult CreatePlacementMatches(Models.PlacementMatchesModel PlacementMatchesModel)
        {
            return Json(PlacementMatchesModel);
        }


        public IActionResult DuoBoosting()
        {
            Models.BoostingModel model = new Models.BoostingModel();
            return View(model);
        }

        public IActionResult WinBoosting()
        {
            Models.BoostingModel model = new Models.BoostingModel();
            return View(model);
        }

        public IActionResult PlacementMatches()
        {
            Models.PlacementMatchesModel model = new Models.PlacementMatchesModel();
            return View(model);
        }
    }
}