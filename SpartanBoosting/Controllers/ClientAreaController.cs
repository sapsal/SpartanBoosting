using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SpartanBoosting.Extensions;
using SpartanBoosting.Models;
using SpartanBoosting.Models.Pricing;
using SpartanBoosting.Models.Repositorys;
using SpartanBoosting.Repositorys;
using SpartanBoosting.Repositorys.Interfaces;
using SpartanBoosting.ViewModel;
using SpartanBoosting.ViewModel.Lol_ViewModels;

namespace SpartanBoosting.Controllers
{
	public partial class ClientAreaController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private IPurchaseOrderRepository PurchaseOrderRepository;
		private IChatModelRepository ChatModelRepository;
		private IUserRepository UserRepository;
		private IAuditRepository AuditRepository;
		public ClientAreaController(IAuditRepository auditRepository, IPurchaseOrderRepository purchaseOrderRepository, IChatModelRepository chatModelRepository, UserManager<ApplicationUser> userManager, IUserRepository userRolesRepository)
		{
			AuditRepository = auditRepository;
			PurchaseOrderRepository = purchaseOrderRepository;
			ChatModelRepository = chatModelRepository;
			_userManager = userManager;
			UserRepository = userRolesRepository;
		}
		public IActionResult Dashboard()
		{
			LolClientAreaDashboardViewModel LolClientAreaDashboardViewModel = new LolClientAreaDashboardViewModel();
			var user = _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value).Result;

			LolClientAreaDashboardViewModel.PurchaseForm = PurchaseOrderRepository.GetPurchaseFormForClient(user);
			return View(LolClientAreaDashboardViewModel);
		}
		public IActionResult OrderDetails([FromQuery(Name = "hash")] string hash)
		{
			LolOrderDetailsViewModel LolOrderDetailsViewModel = new LolOrderDetailsViewModel();
			var user = _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value).Result;

			//LolOrderDetailsViewModel.PurchaseForm = PurchaseOrderRepository.GetPurchaseFormModelsIncludedByClientIdAndUser(int.Parse(EncryptionHelper.Decrypt(hash)), user);
			LolOrderDetailsViewModel.PurchaseForm = PurchaseOrderRepository.GetPurchaseFormModelsIncludedByIdAndUser(int.Parse(EncryptionHelper.Decrypt(hash)), user);
			LolOrderDetailsViewModel.ChatModel = ChatModelRepository.GetChatModelByPurchaseOrder(int.Parse(EncryptionHelper.Decrypt(hash)));

			switch (LolOrderDetailsViewModel.PurchaseForm.PurchaseType)
			{
				case SpartanBoosting.Utils.PurchaseTypeEnum.PurchaseType.SoloBoosting:
				case SpartanBoosting.Utils.PurchaseTypeEnum.PurchaseType.DuoBoosting:
					LolOrderDetailsViewModel.StartDivision = $"{LolOrderDetailsViewModel.PurchaseForm.BoostingModel.YourCurrentLeague} {LolOrderDetailsViewModel.PurchaseForm.BoostingModel.CurrentDivision}";
					LolOrderDetailsViewModel.DesiredDivision = $"{LolOrderDetailsViewModel.PurchaseForm.BoostingModel.DesiredCurrentLeague} {LolOrderDetailsViewModel.PurchaseForm.BoostingModel.DesiredCurrentDivision}";//maybe render html in switch instead of variables
					LolOrderDetailsViewModel.DivisionBoost = $"{LolOrderDetailsViewModel.PurchaseForm.BoostingModel.YourCurrentLeague} {LolOrderDetailsViewModel.PurchaseForm.BoostingModel.CurrentDivision} ({LolOrderDetailsViewModel.PurchaseForm.BoostingModel.CurrentLP}) <span> <i class='fas fa-angle-right'></i> </span> {LolOrderDetailsViewModel.PurchaseForm.BoostingModel.DesiredCurrentLeague} {LolOrderDetailsViewModel.PurchaseForm.BoostingModel.DesiredCurrentDivision}";
					LolOrderDetailsViewModel.Region = LolOrderDetailsViewModel.PurchaseForm.BoostingModel.Server;
					LolOrderDetailsViewModel.Queue = LolOrderDetailsViewModel.PurchaseForm.BoostingModel.TypeOfQueue;
					if (LolOrderDetailsViewModel.PurchaseForm.PurchaseType == SpartanBoosting.Utils.PurchaseTypeEnum.PurchaseType.DuoBoosting)
						LolOrderDetailsViewModel.DuoType = LolOrderDetailsViewModel.PurchaseForm.BoostingModel.TypeOfDuoPremium != "false" ? LolOrderDetailsViewModel.PurchaseForm.BoostingModel.TypeOfDuoPremium : "Regular";
					LolOrderDetailsViewModel.Champions = LolOrderDetailsViewModel.PurchaseForm.BoostingModel.SpecificChampions;
					LolOrderDetailsViewModel.SpecificRoles = LolOrderDetailsViewModel.PurchaseForm.BoostingModel.SpecificRolesTop == "false" ? "" : LolOrderDetailsViewModel.PurchaseForm.BoostingModel.SpecificRolesTop + "," + LolOrderDetailsViewModel.PurchaseForm.BoostingModel.SpecificRolesSupport == "false" ? "" : LolOrderDetailsViewModel.PurchaseForm.BoostingModel.SpecificRolesSupport + ","
					+ LolOrderDetailsViewModel.PurchaseForm.BoostingModel.SpecificRolesMiddle == "false" ? "" : LolOrderDetailsViewModel.PurchaseForm.BoostingModel.SpecificRolesMiddle + "," + LolOrderDetailsViewModel.PurchaseForm.BoostingModel.SpecificRolesJungle == "false" ? "" : LolOrderDetailsViewModel.PurchaseForm.BoostingModel.SpecificRolesJungle + ","
					 + LolOrderDetailsViewModel.PurchaseForm.BoostingModel.SpecificRolesADC == "false" ? "" : LolOrderDetailsViewModel.PurchaseForm.BoostingModel.SpecificRolesADC;
					LolOrderDetailsViewModel.VPN = LolOrderDetailsViewModel.PurchaseForm.BoostingModel.VPN;
					LolOrderDetailsViewModel.LP = LolOrderDetailsViewModel.PurchaseForm.BoostingModel.CurrentLP;
					break;
				case SpartanBoosting.Utils.PurchaseTypeEnum.PurchaseType.WinBoosting:
					LolOrderDetailsViewModel.StartDivision = $"{LolOrderDetailsViewModel.PurchaseForm.WinBoostModel.YourCurrentLeague}{LolOrderDetailsViewModel.PurchaseForm.WinBoostModel.CurrentDivision}";
					LolOrderDetailsViewModel.DivisionBoost = $"{LolOrderDetailsViewModel.PurchaseForm.WinBoostModel.YourCurrentLeague} {LolOrderDetailsViewModel.PurchaseForm.WinBoostModel.CurrentDivision} <span> <i class='fas fa-angle-right'></i> </span> {LolOrderDetailsViewModel.PurchaseForm.WinBoostModel.NumOfGames} ";
					LolOrderDetailsViewModel.Region = LolOrderDetailsViewModel.PurchaseForm.WinBoostModel.Server;
					LolOrderDetailsViewModel.Queue = LolOrderDetailsViewModel.PurchaseForm.WinBoostModel.TypeOfQueue;
					LolOrderDetailsViewModel.DuoType = LolOrderDetailsViewModel.PurchaseForm.WinBoostModel.TypeOfDuoPremium != null ? LolOrderDetailsViewModel.PurchaseForm.WinBoostModel.TypeOfDuoPremium : "Regular";
					LolOrderDetailsViewModel.NumOfGames = LolOrderDetailsViewModel.PurchaseForm.WinBoostModel.NumOfGames;
					break;
				case SpartanBoosting.Utils.PurchaseTypeEnum.PurchaseType.PlacementMatches:
					LolOrderDetailsViewModel.StartDivision = $"{LolOrderDetailsViewModel.PurchaseForm.PlacementMatchesModel.LastSeasonStanding}";
					LolOrderDetailsViewModel.DivisionBoost = $"{LolOrderDetailsViewModel.PurchaseForm.PlacementMatchesModel.LastSeasonStanding} <span> <i class='fas fa-angle-right'></i> </span> {LolOrderDetailsViewModel.PurchaseForm.PlacementMatchesModel.NumOfGames}";
					LolOrderDetailsViewModel.Region = LolOrderDetailsViewModel.PurchaseForm.PlacementMatchesModel.Server;
					LolOrderDetailsViewModel.Queue = LolOrderDetailsViewModel.PurchaseForm.PlacementMatchesModel.TypeOfQueue;
					LolOrderDetailsViewModel.DuoType = LolOrderDetailsViewModel.PurchaseForm.PlacementMatchesModel.TypeOfDuoPremium != null ? LolOrderDetailsViewModel.PurchaseForm.PlacementMatchesModel.TypeOfDuoPremium : "Regular";
					LolOrderDetailsViewModel.ServiceType = $"{LolOrderDetailsViewModel.PurchaseForm.PlacementMatchesModel.TypeOfService}";
					LolOrderDetailsViewModel.NumOfGames = LolOrderDetailsViewModel.PurchaseForm.PlacementMatchesModel.NumOfGames;
					break;
				case SpartanBoosting.Utils.PurchaseTypeEnum.PurchaseType.TFTPlacement:
					LolOrderDetailsViewModel.StartDivision = $"{LolOrderDetailsViewModel.PurchaseForm.TFTPlacementModel.LastSeasonStanding}";
					LolOrderDetailsViewModel.DivisionBoost = $"{LolOrderDetailsViewModel.PurchaseForm.TFTPlacementModel.LastSeasonStanding} <span> <i class='fas fa-angle-right'></i> </span> {LolOrderDetailsViewModel.PurchaseForm.TFTPlacementModel.NumberOfGames}";
					LolOrderDetailsViewModel.Region = LolOrderDetailsViewModel.PurchaseForm.TFTPlacementModel.Server;
					LolOrderDetailsViewModel.NumOfGames = LolOrderDetailsViewModel.PurchaseForm.TFTPlacementModel.NumberOfGames;
					break;
				case SpartanBoosting.Utils.PurchaseTypeEnum.PurchaseType.TFTBoosting:
					LolOrderDetailsViewModel.StartDivision = $"{LolOrderDetailsViewModel.PurchaseForm.TFTBoostingModel.YourCurrentLeague} {LolOrderDetailsViewModel.PurchaseForm.TFTBoostingModel.CurrentDivision}";
					LolOrderDetailsViewModel.DesiredDivision = $"{LolOrderDetailsViewModel.PurchaseForm.TFTBoostingModel.DesiredCurrentLeague} {LolOrderDetailsViewModel.PurchaseForm.TFTBoostingModel.DesiredCurrentDivision}";//maybe render html in switch instead of variables
					LolOrderDetailsViewModel.DivisionBoost = $"{LolOrderDetailsViewModel.PurchaseForm.TFTBoostingModel.YourCurrentLeague} {LolOrderDetailsViewModel.PurchaseForm.TFTBoostingModel.CurrentDivision} ({LolOrderDetailsViewModel.PurchaseForm.TFTBoostingModel.CurrentLP}) <span> <i class='fas fa-angle-right'></i> </span> {LolOrderDetailsViewModel.PurchaseForm.TFTBoostingModel.DesiredCurrentLeague} {LolOrderDetailsViewModel.PurchaseForm.TFTBoostingModel.DesiredCurrentDivision}";
					LolOrderDetailsViewModel.Region = LolOrderDetailsViewModel.PurchaseForm.TFTBoostingModel.Server;
					LolOrderDetailsViewModel.LP = LolOrderDetailsViewModel.PurchaseForm.TFTBoostingModel.CurrentLP;
					break;
				case SpartanBoosting.Utils.PurchaseTypeEnum.PurchaseType.Coaching:
					break;
				default:
					break;
			}
			return View(LolOrderDetailsViewModel);
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
	}
}