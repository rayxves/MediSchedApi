using MediSchedApi.Data;
using MediSchedApi.Interfaces;
using MediSchedApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MediSchedApi.Repository
{
    public class DoctorSpecialtyRepository : IDoctorSpeciality
    {

        private readonly ApplicationDBContext _context;
        public DoctorSpecialtyRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<DoctorSpecialty>> GetAllDoctorSpecialtyGeral()
        {
            var specialty = await _context.Specialties.Where(x => x.Id == Specialty.MedicSpecialityId).FirstOrDefaultAsync();
            var doctorSpecialty = await _context.DoctorSpecialties.Where(ds => ds.SpecialityId == specialty.Id).Include(ds => ds.User).ToListAsync();

            return doctorSpecialty;
        }


        public async Task<List<DoctorSpecialty>> GetDoctorSpecialtyBySymptom(string symptom)
        {
            var symptoms = symptom.ToLower().Split(' ');

            var matchedSpecialties = _context.Specialties
                .Where(s =>
                    s.Keywords.Any(
                            k => symptoms.Any(s => k.Contains(s.ToLower()))))
                .ToList();

            var doctorSpecialty = await _context.DoctorSpecialties
            .Where(ds => matchedSpecialties.Select(s => s.Id).Contains(ds.SpecialityId))
            .Include(ds => ds.User)
            .ToListAsync();

            return doctorSpecialty;
        }

        public async Task<DoctorSpecialty> GetDoctorSpecialtyByUserId(string userId)
        {
            return await _context.DoctorSpecialties
            .Include(ds => ds.Speciality)
            .FirstOrDefaultAsync(ds => ds.UserId == userId);
        }

        public async Task<DoctorSpecialty> UpdateSpecialityAsync(int id, DoctorSpecialty doctorSpecialty)
        {
            var existsDoctorSpeciality = await _context.DoctorSpecialties.FirstOrDefaultAsync(ds => ds.Id == id);

            existsDoctorSpeciality.SpecialityId = doctorSpecialty.SpecialityId;
            existsDoctorSpeciality.Speciality = doctorSpecialty.Speciality;

            await _context.SaveChangesAsync();
            return existsDoctorSpeciality;

        }
    }
}