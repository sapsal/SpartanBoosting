using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpartanBoosting.Models;
using SpartanBoosting.Models.Pricing;
using SpartanBoosting.Models.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SpartanBoosting.Controllers
{
	public partial class BoosterAreaController : Controller
	{

		public IActionResult OrderDetails()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AcceptBoosterJob(int Id)
		{
			var result = PurchaseOrderRepository.GetPurchaseForm(Id);

			if (result.JobAvailable == true)
			{
				var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
				var user = _userManager.FindByIdAsync(id).Result;
				result.BoosterAssignedTo = user;
				result.JobAvailable = false;
				PurchaseOrderRepository.Update(result);
				return Json(new Dictionary<string, string> { { "Username", result.PersonalInformation.UserName }, { "Password", result.PersonalInformation.Password }, { "Discord", result.PersonalInformation.Discord } });
			}

			return Json(null);
		}
		[HttpPost]
		public IActionResult CompleteBoosterJob(int Id)
		{
			var result = PurchaseOrderRepository.GetPurchaseForm(Id);
			var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
			var user = _userManager.FindByIdAsync(id).Result;
			if (result.JobAvailable != true && !result.BoosterCompletionConfirmed && result.BoosterAssignedTo == user)
			{
				result.BoosterCompletionConfirmed = true;
				PurchaseOrderRepository.Update(result);
				return Json(true);
			}

			return Json(false);
		}

		[HttpPost]
		public IActionResult CancellBoosterJob(int Id)
		{
			var result = PurchaseOrderRepository.GetPurchaseForm(Id);
			var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
			var user = _userManager.FindByIdAsync(id).Result;
			if (result.JobAvailable != true && !result.BoosterCompletionConfirmed && result.BoosterAssignedTo == user)
			{
				result.BoosterCompletionConfirmed = false;
				result.BoosterAssignedTo = null;
				result.JobAvailable = true;
				PurchaseOrderRepository.Update(result);
				return Json(true);
			}

			return Json(false);
		}

	}
}
