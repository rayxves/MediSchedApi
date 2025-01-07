using System.Net;
using System.Net.Mail;
using MediSchedApi.Mappers.EmailMapper;
using Microsoft.Extensions.Options;

namespace MediSchedApi.Services
{
    public class EmailService
    {
        private readonly EmailSettings _emailSettings;
        public EmailService(IOptions<EmailSettings> emailSettings) //IOptions<T> é um padrão em ASP.NET Core para acessar configurações mapeadas do appsettings.json ou qualquer outra fonte de configuração
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {

            var smtpClient = new SmtpClient(_emailSettings.SmtpServer)
            {
                Port = _emailSettings.SmtpPort,
                Credentials = new NetworkCredential(_emailSettings.EmailFrom, _emailSettings.EmailPassword),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.EmailFrom), //endereço do email destinatário
                Subject = subject, //assunto
                Body = body, //conteúdo
                IsBodyHtml = true,
            };

            mailMessage.To.Add(toEmail);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}