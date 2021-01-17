using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpartanBoosting.ViewModel;

namespace SpartanBoosting.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            InvoiceViewModel InvoiceViewModel = new InvoiceViewModel();
            return View(InvoiceViewModel);
        }
    }
}