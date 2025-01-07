using System.Threading.Tasks;
using MediSchedApi.Interfaces;
using MediSchedApi.Services;

namespace MediSchedApi.Observables
{
    public class Paciente : IObserver
    {
        private readonly EmailService _emailService;
        public Paciente(EmailService emailService)
        {
            _emailService = emailService;
        }


        public async void Update(string email, string subject, string statusConsultation)
        {
            await _emailService.SendEmailAsync(email, subject, statusConsultation);
        }
    }
}