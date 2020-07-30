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

            string fileName = @"C:\Users\bobby\Source\Repos\SpartanBoosting\SpartanBoosting\Gameboost_Prices_22062020_-_TFT_Update.xlsx";
            FileInfo file = new FileInfo(fileName);
            List<SoloBoostPricing> SoloBoostPricing = new List<SoloBoostPricing>();
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;
                int ColCount = worksheet.Dimension.Columns;

                string CurrentDivision = string.Empty;
                string CurrentLP = string.Empty;
                string RequiredDivision = string.Empty;
                string GameboostPrice = string.Empty;
                string OurPrice = string.Empty;
                for (int row = 5; row <= rowCount; row++)
                {
                    for (int col = 1; col <= ColCount; col++)
                    {

                        if (worksheet.Cells[4, col].Value.ToString() == "Current Division ")
                        {
                            CurrentDivision = $"{worksheet.Cells[row, col].Value}";
                        }
                        if (worksheet.Cells[4, col].Value.ToString() == "Current LP ")
                        {
                            CurrentLP = $"{worksheet.Cells[row, col].Value}";
                        }
                        if (worksheet.Cells[4, col].Value.ToString() == "Required Division ")
                        {
                            RequiredDivision = $"{worksheet.Cells[row, col].Value}";
                        }
                        if (worksheet.Cells[4, col].Value.ToString() == " Gameboost Price")
                        {
                            GameboostPrice = $"{worksheet.Cells[row, col].Value}";
                        }
                        if (worksheet.Cells[4, col].Value.ToString() == "Our Price")
                        {
                            OurPrice = $"{worksheet.Cells[row, col].Value}";
                            SoloBoostPricing.Add(new Models.Pricing.SoloBoostPricing { CurrentDivision = CurrentDivision, CurrentLP = CurrentLP, GameboostPrice = GameboostPrice, OurPrice = OurPrice, RequiredDivision = RequiredDivision });
                        }
                    }
                    CurrentDivision = string.Empty;
                    CurrentLP = string.Empty;
                    RequiredDivision = string.Empty;
                    GameboostPrice = string.Empty;
                    OurPrice = string.Empty;
                }
            }

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