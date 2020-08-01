using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SpartanBoosting.Controllers
{
    public class TFTBoostingController : Controller
    {
        public IActionResult TFTPlacementMatches()
        {
            return View();
        }
        public IActionResult TFTSoloBoost()
        {
            return View();
        }

        [ValidateAntiForgeryToken()]
        [HttpPost]
        public JsonResult CreateTFTSoloBoost(Models.TFTBoostingModel BoostingModel)
        {
            return Json(BoostingModel);
        }
        [ValidateAntiForgeryToken()]
        [HttpPost]
        public JsonResult CreateTFTPlacementBoost(Models.TFTPlacementModel BoostingModel)
        {
            return Json(BoostingModel);
        }
    }
}