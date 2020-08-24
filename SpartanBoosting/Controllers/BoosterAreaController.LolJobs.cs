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

		[HttpPost]
		public IActionResult AcceptBoosterJob(PurchaseForm purchaseForm)
		{
			var result = PurchaseOrderRepository.GetPurchaseForm(purchaseForm.Id);

			if (result.JobAvailable == true)
			{
				var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
				var user = _userManager.FindByIdAsync(id).Result;
				result.BoosterAssignedTo = user;
				result.JobAvailable = false;
				PurchaseOrderRepository.Update(result);
				return Json(new Dictionary<string, string> { { "Username", result.PersonalInformation.UserName }, { "Password", result.PersonalInformation.Password } });
			}

			return Json(null);
		}
	}
}
