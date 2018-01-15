using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressBookApp.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class CoolEmailSender : IEmailSender
    {
        private ILogger<CoolEmailSender> logger { get; set; }
        public CoolEmailSender(ILogger<CoolEmailSender> _logger)
        {
            logger = _logger;
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {
            logger.LogInformation($"Sending '{subject}' to {email}, content is {message}");
            return Task.CompletedTask;
        }
    }
}
