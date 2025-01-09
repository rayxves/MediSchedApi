using MediSchedApi.Models;

namespace MediSchedApi.Interfaces
{
    public interface IDoctorSpeciality
    {
        Task<List<DoctorSpecialty>> GetDoctorSpecialtyBySymptom(string symptom);
        Task<List<DoctorSpecialty>> GetAllDoctorSpecialtyGeral();
        Task<DoctorSpecialty> GetDoctorSpecialtyByUserId(string userId);
        Task<DoctorSpecialty> UpdateSpecialityAsync(int id, DoctorSpecialty doctorSpecialty);
    }
}