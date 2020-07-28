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
    }
}