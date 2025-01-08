using MediSchedApi.Models;

namespace MediSchedApi.Interfaces
{
    public interface IConsultationReportRepository
    {
        Task<List<ConsulationReport>> GetAllConsultationReport();
        Task<List<ConsulationReport>> GetAllConsultationReportByDoctor(User user);
        Task<ConsulationReport> AddToConsulationReportAsync(ConsulationReport consultationReport);
        Task<ConsulationReport> DeleteConsultationReportAsync(ConsulationReport consultationReport);

    }
}