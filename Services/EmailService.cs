using System.Net;
using System.Net.Mail;
using MediSchedApi.Mappers.EmailMapper;
using Microsoft.Extensions.Options;

namespace MediSchedApi.Services
{
    public class EmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
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
                From = new MailAddress(_emailSettings.EmailFrom),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(toEmail);

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
                Console.WriteLine($"E-mail enviado com sucesso para {toEmail}");
            }
            catch (SmtpFailedRecipientException ex)
            {
                Console.WriteLine($"Falha ao enviar o e-mail para {ex.FailedRecipient}: {ex.Message}");
                throw new Exception($"Falha no envio do e-mail para o destinatário {ex.FailedRecipient}", ex);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine("Erro SMTP: " + ex.Message);
                Console.WriteLine("Código de status: " + ex.StatusCode);

                if (ex.StatusCode == SmtpStatusCode.GeneralFailure)
                {
                    throw new Exception("Falha na conexão SMTP. Verifique o servidor e as credenciais.", ex);
                }
                else if (ex.StatusCode == SmtpStatusCode.MailboxUnavailable)
                {
                    throw new Exception("A caixa de e-mail do destinatário está indisponível.", ex);
                }
                else if (ex.StatusCode == SmtpStatusCode.ClientNotPermitted)
                {
                    throw new Exception("O cliente não tem permissão para enviar e-mails. Verifique as configurações do servidor SMTP.", ex);
                }
                else
                {
                    throw new Exception("Ocorreu um erro SMTP ao enviar o e-mail.", ex);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro inesperado ao enviar o e-mail: " + ex.Message);
                throw new Exception("Erro inesperado ao enviar o e-mail.", ex);
            }
        }
    }
}
