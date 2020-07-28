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
            return View();
        }
    }
}