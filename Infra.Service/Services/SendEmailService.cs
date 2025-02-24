using Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Infra.Service.Services
{
    public class SendEmailService : ISendEmailService
    {
        private readonly string _host;
        private readonly int _port;
        private readonly string _senderEmail;
        private readonly string _password;

        public SendEmailService(IConfiguration configuration)
        {
            _host = configuration["Smtp:Host"];
            _port = int.Parse(configuration["Smtp:Port"]);
            _senderEmail = configuration["Smtp:SenderEmail"];
            _password = configuration["Smtp:Password"];
        }

        public async Task<bool> SendEmail(string recipient, string subject, string message)
        {

            SmtpClient client = new SmtpClient(_host)
            {
                Port = _port,
                Credentials = new NetworkCredential(_senderEmail, _password),
                EnableSsl = true,
                UseDefaultCredentials = false
            };

            MailMessage mailMessage = new MailMessage(_senderEmail, recipient, subject, message);
            try
            {
                await client.SendMailAsync(mailMessage);
                return (true);
            }
            catch (Exception err)
            {
                return (false);
            }
        }
    }
}
