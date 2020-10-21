using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SpartanBoosting.Extensions;
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

		public IActionResult OrderDetails([FromQuery(Name = "hash")] string hash)
		{
			if (User.IsInRole("Superuser"))
			{
				var model = PurchaseOrderRepository.GetPurchaseFormModelsIncludedById(int.Parse(EncryptionHelper.Decrypt(hash)));
				return View(model);
			}
			else
			{
				var user = _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value).Result;
				var model = PurchaseOrderRepository.GetPurchaseFormModelsIncludedByIdAndUser(int.Parse(EncryptionHelper.Decrypt(hash)), user);
				return View(model);
			}
		}

		[HttpPost]
		public IActionResult AddChatModel(string message, string purchaseForm)
		{
			var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
			var user = _userManager.FindByIdAsync(id).Result;
			PurchaseForm PurchaseFormOrder = new PurchaseForm() { Id = JsonConvert.DeserializeObject<PurchaseForm>(EncryptionHelper.Decrypt(purchaseForm)).Id };

			ChatModel chatModel = new ChatModel()
			{
				Sender = user,
				DateTimeSent = DateTime.UtcNow,
				Message = message,
				purchaseForm = PurchaseFormOrder
			};

			var result = ChatModelRepository.Add(chatModel);
			return Json(true);
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
