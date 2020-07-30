using LinqToExcel;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using SpartanBoosting.Models.Pricing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        [ValidateAntiForgeryToken()]
        [HttpPost]
        public JsonResult CreateWinBoost(Models.WinBoostModel WinBoostModel)
        {
            return Json(WinBoostModel);
        }


        public IActionResult DuoBoosting()
        {
            Models.BoostingModel model = new Models.BoostingModel();
            return View(model);
        }

        public IActionResult WinBoosting()
        {
            Models.WinBoostModel model = new Models.WinBoostModel();
            return View(model);
        }

        public IActionResult PlacementMatches()
        {
            Models.PlacementMatchesModel model = new Models.PlacementMatchesModel();
            return View(model);
        }
    }
}