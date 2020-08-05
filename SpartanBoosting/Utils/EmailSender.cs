using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SpartanBoosting.Utils
{
    public class EmailSender 
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailSender(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;

        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //https://kenhaggerty.com/articles/article/aspnet-core-22-smtp-emailsender-implementation
        }
    }
}
