using MediSchedApi.Data;
using MediSchedApi.Interfaces;
using MediSchedApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MediSchedApi.Repository
{
    public class ConsultationReportRepository : IConsultationReportRepository
    {
        ApplicationDBContext _context;
        public ConsultationReportRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<ConsultationReport> AddToConsultationReportAsync(ConsultationReport consultationReport)
        {
            await _context.ConsultationReports.AddAsync(consultationReport);
            await _context.SaveChangesAsync();
            return consultationReport;
        }

        public async Task<ConsultationReport> DeleteConsultationReportAsync(ConsultationReport consultationReport)
        {
            _context.ConsultationReports.Remove(consultationReport);
            await _context.SaveChangesAsync();
            return consultationReport;
        }

        public async Task<List<ConsultationReport>> GetAllConsultationReport()
        {
            return await _context.ConsultationReports
            .Include(c => c.Medico)
            .Include(c => c.DoctorSpecialty)
            .ThenInclude(ds => ds.Speciality)
            .ToListAsync();
        }

        public async Task<List<ConsultationReport>> GetAllConsultationReportByDoctor(User user)
        {
            return await _context.ConsultationReports
            .Where(c => c.MedicoId == user.Id)
            .ToListAsync();
        }

        public async Task<List<ConsultationReport>> GetAllConsultationReportBySpeciality(string speciality)
        {
            return await _context.ConsultationReports
            .Where(cs => cs.DoctorSpecialty.Speciality.Name.ToLower() == speciality.ToLower())
                .Include(cs => cs.Medico)
                .Include(cs => cs.DoctorSpecialty)
                .ThenInclude(ds => ds.Speciality)
                .ToListAsync();
        }

        public async Task<ConsultationReport> GetConsultationReportById(int id)
        {
            return await _context.ConsultationReports.FirstOrDefaultAsync(cr => cr.Id == id);
        }
    }
}