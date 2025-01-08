using MediSchedApi.Data;
using MediSchedApi.Interfaces;
using MediSchedApi.Models;
using MediSchedApi.Observable;
using MediSchedApi.Services;
using Microsoft.EntityFrameworkCore;

namespace MediSchedApi.Repository
{
    public class ConsultationRepository : IConsultationRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly EmailService _emailService;
        public ConsultationRepository(ApplicationDBContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public async Task<Consultation> AddToConsulationAsync(Consultation consultation)
        {
            await _context.Consultations.AddAsync(consultation);
            await _context.SaveChangesAsync();

            return consultation;
        }


        public async Task<Consultation> DeleteConsultationAsync(Consultation consultation)
        {
            _context.Consultations.Remove(consultation);
            await _context.SaveChangesAsync();
            return consultation;
        }


        public async Task<List<Consultation>> GetConsultationByDate(DateTime? date)
        {
            return await _context.Consultations.Where(c => c.Data == date).ToListAsync();
        }

        public async Task<Consultation> GetConsultationById(int id)
        {
            return await _context.Consultations.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Consultation>> GetConsultationByUser(User user)
        {
            return await _context.Consultations.Where(c => c.Medico == user).ToListAsync();
        }

        public async Task NotifierConsultation(string email, string subject, string statusConsultation)
        {
            var newObserver = new Observer(_emailService);
            var consultationNotfier = new ConsultationNotifier();

            consultationNotfier.AddObserver(newObserver);
            await consultationNotfier.NotifyObservers(email, subject, statusConsultation);

        }
    }
}