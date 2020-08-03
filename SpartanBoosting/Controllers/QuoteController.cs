using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SpartanBoosting.Models.Pricing;
using SpartanBoosting.Utils;

namespace SpartanBoosting.Controllers
{
	public class QuoteController : Controller
	{
		public IActionResult PurchaseQuote()
		{
			PurchaseForm purchaseForm = JsonConvert.DeserializeObject<PurchaseForm>(TempData["purchaseFormlData"].ToString());
			var bot = new DiscordBot();
			bot.RunAsync(purchaseForm).GetAwaiter().GetResult();
			return View();
		}
	}
}