using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SpartanBoosting.Models.Pricing;
using SpartanBoosting.Utils;

namespace SpartanBoosting.Controllers
{
	public class QuoteController : Controller
	{
		private readonly IOptions<SmtpSettings> _smtpSettings;

		public QuoteController(IOptions<SmtpSettings> smtpSettings)
		{
			_smtpSettings = smtpSettings;

		}
		public IActionResult PurchaseQuote()
		{
			PurchaseForm purchaseForm = JsonConvert.DeserializeObject<PurchaseForm>(TempData["purchaseFormlData"].ToString());
			var bot = new DiscordBot();
			bot.RunAsync(purchaseForm).GetAwaiter().GetResult();
			EmailSender email = new EmailSender(_smtpSettings);
			email.SendEmailAsync("Purchase Request", $"Purchase Request", TempData["purchaseFormlData"].ToString());
			return RedirectToAction("Index", "Home");
		}
	}
}