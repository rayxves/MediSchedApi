using MediSchedApi.Data;
using MediSchedApi.Interfaces;
using MediSchedApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MediSchedApi.Repository
{
    public class ConsulationRepository : IConsulationRepository
    {
        private readonly ApplicationDBContext _context;
        public ConsulationRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Consultation> AddToConsulationAsync(Consultation consultation)
        {
            await _context.Consultations.AddAsync(consultation);
            await _context.SaveChangesAsync();

            return consultation;
        }

        public async Task<List<Consultation>> GetConsultationByDate(DateTime? date)
        {
            return await _context.Consultations.Where(c => c.Data == date).ToListAsync();
        }

        public async Task<List<Consultation>> GetConsultationByUser(User user)
        {
            return await _context.Consultations.Where(c => c.Medico == user).ToListAsync();
        }

        public async Task<List<DoctorSpecialty>> GetDoctorSpecialtyBySymptom(string symptom)
        {
            var specialties = await _context.Specialties.ToListAsync();
            var matchedSpecialties = new List<Specialty>();

            foreach (var specialty in specialties)
            {
                foreach (var key in specialty.Keywords)
                {
                    if (symptom.ToLower().Contains(key.ToLower()))
                    {
                        matchedSpecialties.Add(specialty);
                    }
                }
            }

            var doctorSpecialty = await _context.DoctorSpecialties
            .Where(ds => matchedSpecialties.Select(s => s.Id).Contains(ds.SpecialtyId))
            .Include(ds => ds.User)
            .ToListAsync();

            return doctorSpecialty;
        }
    }
}