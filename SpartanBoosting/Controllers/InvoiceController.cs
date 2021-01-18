using System;
using Microsoft.AspNetCore.Mvc;
using SpartanBoosting.Extensions;
using SpartanBoosting.Models.Pricing;
using SpartanBoosting.ViewModel;
using static SpartanBoosting.Utils.PurchaseTypeEnum;

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
            Enum.TryParse("Active", out PurchaseType myStatus);
            InvoiceViewModel.PurchaseType = myStatus;
            InvoiceViewModel.PurchaseForm = TempData.Get<PurchaseForm>("purchaseForm");
            return View(InvoiceViewModel);
        }
    }
}