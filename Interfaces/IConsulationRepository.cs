using MediSchedApi.Models;

namespace MediSchedApi.Interfaces
{
    public interface IConsulationRepository
    {
        Task<List<DoctorSpecialty>> GetDoctorSpecialtyBySymptom(string symptom);
        Task<List<Consultation>> GetConsultationByDate(DateTime? date);
        Task<List<Consultation>> GetConsultationByUser(User user);
        Task<Consultation> AddToConsulationAsync(Consultation consultation);
    }
}