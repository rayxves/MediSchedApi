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

        public async Task<List<Consultation>> GetAllConsultations()
        {
            return await _context.Consultations
            .Include(c => c.Medico)
            .Include(c => c.Paciente)
            .ToListAsync();
        }

        public async Task<List<Consultation>> GetConsultationByDate(DateTime? date)
        {
            return await _context.Consultations.Where(c => c.Data == date).ToListAsync();
        }

        public async Task<Consultation> GetConsultationById(int id)
        {
            return await _context.Consultations.FirstOrDefaultAsync(c => c.Id == id);
        }



        public async Task NotifierConsultation(string userName, string doctorName, string email, DateTime consultationDate)
        {
            var emailBody = _emailService.GenerateEmailHtml(userName, doctorName, consultationDate);
            var newObserver = new Observer(_emailService);
            var consultationNotfier = new ConsultationNotifier();

            var subject = "Nova consulta.";

            consultationNotfier.AddObserver(newObserver);
            await consultationNotfier.NotifyObservers(email, subject, emailBody);

        }

        public Task<List<Consultation>> GetConsultationByUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "Usuário não pode ser nulo.");
            }

            if (user.Role == null)
            {
                throw new InvalidOperationException("O usuário não possui um papel associado.");
            }

            if (string.IsNullOrEmpty(user.Role.Name))
            {
                throw new InvalidOperationException("O nome do papel do usuário não é válido.");
            }

            if (user.Role.Name == "Paciente")
            {
                return _context.Consultations
                    .Where(c => c.Paciente != null && c.Paciente == user)
                    .ToListAsync();
            }
            else if (user.Role.Name == "Medico")
            {
                return _context.Consultations
                    .Where(c => c.Medico != null && c.Medico == user)
                    .ToListAsync();
            }
            else
            {
                throw new InvalidOperationException("Papel de usuário não reconhecido.");
            }
        }

        public async Task<List<Consultation>> GetConsultationsByStatusAndDate(string status, DateTime data)
        {
            DateTime utcData = data.Kind == DateTimeKind.Local ? data.ToUniversalTime() : data;
            return await _context.Consultations.Where(c => c.Status == status && c.Data > utcData).ToListAsync();
        }

        public async Task UpdateConsultationStatus(Consultation consultation)
        {
            var consultationExists = await _context.Consultations.FirstOrDefaultAsync(c => c.Id == consultation.Id);
            consultationExists.Status = consultation.Status;
            await _context.SaveChangesAsync();
        }
    }
}