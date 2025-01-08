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

        public string GenerateEmailHtml(string userName, string doctorName, DateTime consultationDate)
        {
            return $@"<html>
                <body style='font-family: Arial, sans-serif; line-height: 1.6; background-color: #f9f9f9; margin: 0; padding: 20px;'>
                    <div style='max-width: 600px; margin: auto; background: #ffffff; border-radius: 8px; box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);'>
                    <!-- Cabeçalho -->
                    <div style='background-color: #2c3e50; color: #ffffff; padding: 20px; border-radius: 8px 8px 0 0; text-align: center;'>
                        <h2 style='margin: 0;'>Consulta Confirmada!</h2>
                    </div>
                    <!-- Corpo do Email -->
                    <div style='padding: 20px;'>
                        <p>Uma nova consulta foi agendada:</p>
                        <p><strong>Data:</strong> {consultationDate:dd/MM/yyyy} às {consultationDate:HH:mm}</p>
                        <p><strong>Médico:</strong> Dr(a). {doctorName}</p>
                        <p><strong>Paciente:</strong> {userName}</p>
                        <p>Por favor, entre em contato em caso de dúvidas.</p>
                        <br />
                        <p style='color: #555555; font-size: 14px;'>Atenciosamente,</p>
                        <p><strong>MediSched</strong></p>
                    </div>
                    <!-- Rodapé -->
                    <div style='background-color: #f4f4f4; color: #777777; padding: 10px; text-align: center; font-size: 12px; border-radius: 0 0 8px 8px;'>
                        <p>© 2025 MediSched. Todos os direitos reservados.</p>
                    </div>
                    </div>
                </body>
                </html>";
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
