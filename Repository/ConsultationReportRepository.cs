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
        public async Task<ConsulationReport> AddToConsulationReportAsync(ConsulationReport consultationReport)
        {
            await _context.ConsulationReports.AddAsync(consultationReport);
            await _context.SaveChangesAsync();
            return consultationReport;
        }

        public async Task<ConsulationReport> DeleteConsultationReportAsync(ConsulationReport consultationReport)
        {
            _context.ConsulationReports.Remove(consultationReport);
            await _context.SaveChangesAsync();
            return consultationReport;
        }

        public async Task<List<ConsulationReport>> GetAllConsultationReport()
        {
            return await _context.ConsulationReports
            .Include(c => c.Medico)
            .ToListAsync();
        }

        public async Task<List<ConsulationReport>> GetAllConsultationReportByDoctor(User user)
        {
            return await _context.ConsulationReports.Where(c => c.Medico == user).ToListAsync();   
        }
    }
}