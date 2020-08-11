using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SpartanBoosting.Models.Adhoc;
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
            return View();
        }

        public IActionResult SubmitContactUs(ContactUsModel ContactUsModel)
        {
            EmailSender test = new EmailSender(_smtpSettings);
            if (!string.IsNullOrEmpty(ContactUsModel.YourEmail) && !string.IsNullOrEmpty(ContactUsModel.Message))
            {
                TempData["Result"] = "Success, Email has been sent";
                test.SendEmailAsync(ContactUsModel.YourEmail, $"{ContactUsModel.YourName} query", ContactUsModel.Message);
            }
            return RedirectToAction("ContactUs", "Adhoc");
        }

        public IActionResult SubmitJoinTheTeam(JoinTheTeamModel JoinTheTeamModel)
        {
            EmailSender email = new EmailSender(_smtpSettings);
            TempData["Result"] = "Success, Email has been sent";
            email.SendEmailAsync(JoinTheTeamModel.Email, $"Join The Team Request", JsonConvert.SerializeObject(JoinTheTeamModel));
            return RedirectToAction("JoinTheTeam", "Adhoc");
        }
    }
}