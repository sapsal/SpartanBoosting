﻿using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SpartanBoosting.Utils
{
	public interface IEmailSender
	{
		Task SendEmailAsync(string email, string subject, string message);
	}
	public class EmailSender : IEmailSender
	{
        private readonly SmtpSettings _smtpSettings;

        public EmailSender(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;

        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.Subject = subject;
                message.Body = htmlMessage;
                message.IsBodyHtml = true;
                message.To.Add("bobbywardell@hotmail.com");

                string host = _smtpSettings.Server;
                int port = _smtpSettings.Port;
                string fromAddress = _smtpSettings.FromAddress;

                message.From = new MailAddress(fromAddress);
                using (var smtpClient = new SmtpClient(host, port))
                {
                    smtpClient.Credentials = new System.Net.NetworkCredential("SpartanBoosting@robertdomain.com", "Tel829988@");
                    await smtpClient.SendMailAsync(message);
                }
            } catch (Exception e ) 
            { 
            }
        }
    }
}
