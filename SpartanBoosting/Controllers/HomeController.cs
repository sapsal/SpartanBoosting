using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpartanBoosting.Models;
using SpartanBoosting.Models.Repositorys;
using SpartanBoosting.Repositorys;
using SpartanBoosting.ViewModel;
namespace SpartanBoosting.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private IUserRepository UserRepository;
		private IPurchaseOrderRepository PurchaseOrderRepository;
		public HomeController(IPurchaseOrderRepository purchaseOrderRepository,	ILogger<HomeController> logger, IUserRepository userRepository)
		{
			PurchaseOrderRepository = purchaseOrderRepository;
			_logger = logger;
			UserRepository = userRepository;
		}

		public IActionResult Index()
		{
			LolHomePageViewModel LolHomePageViewModel = new LolHomePageViewModel();
			LolHomePageViewModel.CompletedBoost = PurchaseOrderRepository.GetBasicPurchaseOrder().Count() * 3;
			LolHomePageViewModel.Boosters = UserRepository.GetUsers().Count();
			return View(LolHomePageViewModel);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult TestCopy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
