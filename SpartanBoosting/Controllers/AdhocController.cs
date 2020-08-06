using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SpartanBoosting.Utils;

namespace SpartanBoosting.Controllers
{
    public class AdhocController : Controller
    {
        private readonly IOptions<SmtpSettings> _smtpSettings;

        public AdhocController(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings;

        }
        public IActionResult PriceBeatGuarantee()
        {
            return View();
        }
        public IActionResult TermsOfService()
        {
            return View();
        }
        public IActionResult FAQ()
        {
            return View();
        }
        public IActionResult JoinTheTeam()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            EmailSender test = new EmailSender(_smtpSettings);
            test.SendEmailAsync("", "", "");
            return View();
        }
    }
}