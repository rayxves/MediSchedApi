using MediSchedApi.Interfaces;
using MediSchedApi.Services;

namespace MediSchedApi.Observable
{
    public class Observer : IObserver
    {
        private readonly EmailService _emailService;
        public Observer(EmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Update(string email, string subject, string statusConsultation)
        {
            await _emailService.SendEmailAsync(email, subject, statusConsultation);
        }
    }
}