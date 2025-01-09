using MediSchedApi.Models;

namespace MediSchedApi.Interfaces
{
    public interface IConsultationReportRepository
    {
        Task<List<ConsultationReport>> GetAllConsultationReport();
        Task<List<ConsultationReport>> GetAllConsultationReportByDoctor(User user);
        Task<ConsultationReport> GetConsultationReportById(int id);
        Task<List<ConsultationReport>> GetAllConsultationReportBySpeciality(string speciality);
        Task<ConsultationReport> AddToConsultationReportAsync(ConsultationReport consultationReport);
        Task<ConsultationReport> DeleteConsultationReportAsync(ConsultationReport consultationReport);
    

    }
}