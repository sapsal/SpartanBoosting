﻿using Microsoft.AspNetCore.Identity;
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
using SpartanBoosting.ViewModel;
using SpartanBoosting.Models.LeagueOfLegends_Models;

namespace SpartanBoosting.Controllers
{
	public partial class BoosterAreaController : Controller
	{

		public IActionResult OrderDetails([FromQuery(Name = "hash")] string hash)
		{
			LolOrderDetailsViewModel LolOrderDetailsViewModel = new LolOrderDetailsViewModel();
			var user = _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value).Result;
			LolOrderDetailsViewModel.CurrentUser = user;

			if (User.IsInRole("Superuser"))
			{
				LolOrderDetailsViewModel.PurchaseForm = PurchaseOrderRepository.GetPurchaseFormModelsIncludedById(int.Parse(EncryptionHelper.Decrypt(hash)));
				LolOrderDetailsViewModel.ChatModel = ChatModelRepository.GetChatModelByPurchaseOrder(int.Parse(EncryptionHelper.Decrypt(hash)));
				return View(LolOrderDetailsViewModel);
			}
			else
			{
				LolOrderDetailsViewModel.PurchaseForm = PurchaseOrderRepository.GetPurchaseFormModelsIncludedByIdAndUser(int.Parse(EncryptionHelper.Decrypt(hash)), user);
				LolOrderDetailsViewModel.ChatModel = ChatModelRepository.GetChatModelByPurchaseOrder(int.Parse(EncryptionHelper.Decrypt(hash)));
				return View(LolOrderDetailsViewModel);
			}
		}

		[HttpPost]
		public IActionResult AddChatModel(string message, string purchaseForm)
		{
			try
			{
				var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
				var user = _userManager.FindByIdAsync(id).Result;
				if (user != null)
				{
					int PurchaseFormOrder = JsonConvert.DeserializeObject<PurchaseForm>(EncryptionHelper.Decrypt(purchaseForm)).Id;

					ChatModel chatModel = new ChatModel()
					{
						Sender = user,
						DateTimeSent = DateTime.UtcNow,
						Message = message,
						purchaseFormId = PurchaseFormOrder
					};

					var result = ChatModelRepository.Add(chatModel);

					return Json(true);
				}
				else
					return Json(false);
			}
			catch
			{
				return Json(false);
			}
		}

		[HttpPost]
		public IActionResult AcceptBoosterJob(int Id)
		{
			var result = PurchaseOrderRepository.GetPurchaseForm(Id);

			if (result.JobAvailable == true)
			{
				var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
				var user = _userManager.FindByIdAsync(id).Result;
				if (!(PurchaseOrderRepository.GetPurchaseFormWithBoosterCount(user) > user.MaxAssignedBoostsAllowed))
				{
					result.BoosterAssignedTo = user;
					result.JobAvailable = false;
					PurchaseOrderRepository.Update(result);
					AuditRepository.Add(new LeagueOfLegendsAuditModel { User = user, DateTime = DateTime.UtcNow, Action = $"Accepted Job By Booster [{JsonConvert.SerializeObject(result)}]" });
					return Json(new
					{
						Username = result.PersonalInformation.UserName,
						Password = result.PersonalInformation.Password,
						Discord = result.PersonalInformation.Discord,
						success = true,
						clientLoginPresent = result.ClientAssignedTo != null,
						message = "Customer can communicate through the chat window on the order details screen"
					});
				}
				else
				{
					return Json(new { success = false, Message = $"You currently have {user.MaxAssignedBoostsAllowed} jobs, please complete the ones you have before accepting more." });

				}
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
				AuditRepository.Add(new LeagueOfLegendsAuditModel { User = user, DateTime = DateTime.UtcNow, Action = $"Completed Job By Booster [{JsonConvert.SerializeObject(result)}]" });
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
				AuditRepository.Add(new LeagueOfLegendsAuditModel { User = user, DateTime = DateTime.UtcNow, Action = $"Cancelled Job By Booster [{JsonConvert.SerializeObject(result)}]" });
				return Json(true);
			}

			return Json(false);
		}

	}
}
