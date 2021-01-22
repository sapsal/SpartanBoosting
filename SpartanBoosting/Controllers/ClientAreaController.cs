using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpartanBoosting.Extensions;
using SpartanBoosting.Models;
using SpartanBoosting.Models.Repositorys;
using SpartanBoosting.Repositorys;
using SpartanBoosting.Repositorys.Interfaces;
using SpartanBoosting.ViewModel;
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
		public IActionResult OrderDetails([FromQuery(Name = "hash")] string hash)
		{
			LolOrderDetailsViewModel LolOrderDetailsViewModel = new LolOrderDetailsViewModel();
			var user = _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value).Result;
			LolOrderDetailsViewModel.PurchaseForm = PurchaseOrderRepository.GetPurchaseFormModelsIncludedByIdAndUser(int.Parse(EncryptionHelper.Decrypt(hash)), user);
			LolOrderDetailsViewModel.ChatModel = ChatModelRepository.GetChatModelByPurchaseOrder(int.Parse(EncryptionHelper.Decrypt(hash)));
			switch (LolOrderDetailsViewModel.PurchaseForm.PurchaseType)
			{
				case SpartanBoosting.Utils.PurchaseTypeEnum.PurchaseType.SoloBoosting:
				case SpartanBoosting.Utils.PurchaseTypeEnum.PurchaseType.DuoBoosting:
					LolOrderDetailsViewModel.StartDivisionImage = $"{LolOrderDetailsViewModel.PurchaseForm.BoostingModel.YourCurrentLeague}{LolOrderDetailsViewModel.PurchaseForm.BoostingModel.CurrentDivision}";
					LolOrderDetailsViewModel.DesiredDivisionImage = $"{LolOrderDetailsViewModel.PurchaseForm.BoostingModel.DesiredCurrentLeague}{LolOrderDetailsViewModel.PurchaseForm.BoostingModel.DesiredCurrentDivision}";//maybe render html in switch instead of variables
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
					LolOrderDetailsViewModel.StartDivisionImage = $"{LolOrderDetailsViewModel.PurchaseForm.WinBoostModel.YourCurrentLeague}{LolOrderDetailsViewModel.PurchaseForm.WinBoostModel.CurrentDivision}";
					//LolOrderDetailsViewModel.DesiredDivisionImage = $"{Model.PurchaseForm.WinBoostModel.DesiredCurrentLeague}{Model.PurchaseForm.WinBoostModel.DesiredCurrentDivision}";//maybe render html in switch instead of variables
					LolOrderDetailsViewModel.DivisionBoost = $"{LolOrderDetailsViewModel.PurchaseForm.WinBoostModel.YourCurrentLeague} {LolOrderDetailsViewModel.PurchaseForm.WinBoostModel.CurrentDivision} <span> <i class='fas fa-angle-right'></i> </span> {LolOrderDetailsViewModel.PurchaseForm.WinBoostModel.NumOfGames} ";
					LolOrderDetailsViewModel.Region = LolOrderDetailsViewModel.PurchaseForm.WinBoostModel.Server;
					LolOrderDetailsViewModel.Queue = LolOrderDetailsViewModel.PurchaseForm.WinBoostModel.TypeOfQueue;
					LolOrderDetailsViewModel.DuoType = LolOrderDetailsViewModel.PurchaseForm.WinBoostModel.TypeOfDuoPremium != null ? LolOrderDetailsViewModel.PurchaseForm.WinBoostModel.TypeOfDuoPremium : "Regular";
					break;
				case SpartanBoosting.Utils.PurchaseTypeEnum.PurchaseType.PlacementMatches:
					LolOrderDetailsViewModel.StartDivisionImage = $"{LolOrderDetailsViewModel.PurchaseForm.PlacementMatchesModel.LastSeasonStanding}";
					LolOrderDetailsViewModel.DivisionBoost = $"{LolOrderDetailsViewModel.PurchaseForm.PlacementMatchesModel.LastSeasonStanding} <span> <i class='fas fa-angle-right'></i> </span> {LolOrderDetailsViewModel.PurchaseForm.PlacementMatchesModel.NumOfGames}";
					LolOrderDetailsViewModel.Region = LolOrderDetailsViewModel.PurchaseForm.PlacementMatchesModel.Server;
					LolOrderDetailsViewModel.Queue = LolOrderDetailsViewModel.PurchaseForm.PlacementMatchesModel.TypeOfQueue;
					LolOrderDetailsViewModel.DuoType = LolOrderDetailsViewModel.PurchaseForm.PlacementMatchesModel.TypeOfDuoPremium != null ? LolOrderDetailsViewModel.PurchaseForm.PlacementMatchesModel.TypeOfDuoPremium : "Regular";
					LolOrderDetailsViewModel.ServiceType = $"{LolOrderDetailsViewModel.PurchaseForm.PlacementMatchesModel.TypeOfService}";
					LolOrderDetailsViewModel.LP = LolOrderDetailsViewModel.PurchaseForm.BoostingModel.CurrentLP;
					break;
				case SpartanBoosting.Utils.PurchaseTypeEnum.PurchaseType.TFTPlacement:
					break;
				case SpartanBoosting.Utils.PurchaseTypeEnum.PurchaseType.TFTBoosting:
					break;
				case SpartanBoosting.Utils.PurchaseTypeEnum.PurchaseType.Coaching:
					break;
				default:
					break;
			}
			return View(LolOrderDetailsViewModel);
		}
	}
}