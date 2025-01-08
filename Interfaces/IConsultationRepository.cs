using MediSchedApi.Models;

namespace MediSchedApi.Interfaces
{
    public interface IConsultationRepository
    {
        Task<List<DoctorSpecialty>> GetDoctorSpecialtyBySymptom(string symptom);
        Task<List<Consultation>> GetConsultationByDate(DateTime? date);
        Task<List<Consultation>> GetConsultationByUser(User user);
        Task<Consultation> GetConsultationById(int id);
        Task<Consultation> AddToConsulationAsync(Consultation consultation);
        Task NotifierConsultation(string email, string subject, string statusConsultation);
        Task<Consultation> DeleteConsultationAsync(Consultation consultation);
    }
}