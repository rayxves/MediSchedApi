using MediSchedApi.Models;

namespace MediSchedApi.Interfaces
{
    public interface IConsultationRepository
    {

        Task<List<Consultation>> GetAllConsultations();
        Task<List<Consultation>> GetConsultationByDate(DateTime? date);
        Task<List<Consultation>> GetConsultationByUser(User user); Task<Consultation> GetConsultationById(int id);
        Task<Consultation> AddToConsulationAsync(Consultation consultation);
        Task NotifierConsultation(string userName, string doctorName, string email, DateTime consultationDate);
        Task<Consultation> DeleteConsultationAsync(Consultation consultation);
        Task<List<Consultation>> GetConsultationsByStatusAndDate(string status, DateTime data);
        Task UpdateConsultationStatus(Consultation consultation);
    }
}