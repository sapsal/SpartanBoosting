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
		public IActionResult Details([FromQuery(Name = "data")] string data, [FromQuery(Name = "dest")] string dest)
		{
			InvoiceViewModel InvoiceViewModel = new InvoiceViewModel();
			InvoiceViewModel.PurchaseForm = TempData.Get<PurchaseForm>("purchaseForm");

			//for refresh
			TempData.Put("purchaseForm", InvoiceViewModel.PurchaseForm);

			if (InvoiceViewModel.PurchaseForm != null)
				return View(InvoiceViewModel);
			else
			{
				return RedirectToAction(EncryptionHelper.Decrypt(data), EncryptionHelper.Decrypt(dest));
			}
		}
	}
}