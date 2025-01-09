

using MediSchedApi.Data;
using MediSchedApi.Dtos.DoctorSpecilityDto;
using MediSchedApi.Interfaces;
using MediSchedApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediSchedApi.Controllers
{
    [Microsoft.AspNetCore.Components.Route("/doctor-specialty")]
    [ApiController]
    public class DoctorSpealtyController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDBContext _context;
        private readonly IDoctorSpeciality _doctorSpeciality;
        public DoctorSpealtyController(UserManager<User> userManager, ApplicationDBContext context, IDoctorSpeciality doctorSpeciality)
        {
            _context = context;
            _userManager = userManager;
            _doctorSpeciality = doctorSpeciality;
        }

        [Authorize(Roles = "Adm")]
        [HttpPost("associate")]
        public async Task<IActionResult> AssociateDoctorToSpecialty(string user_name, string specialty_name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(user_name))
            {
                return BadRequest("Nome do usúario não fornecido.");
            }
            else if (string.IsNullOrEmpty(specialty_name))
            {
                return BadRequest("Nome da especialidade não fornecido.");
            }

            var user = await _userManager.FindByNameAsync(user_name);
            if (user == null)
            {
                return BadRequest("Usuário não encontrado.");
            }
            var specialty = await _context.Specialties.FirstOrDefaultAsync(s => s.Name.ToLower() == specialty_name.ToLower());
            if (specialty == null)
            {
                return NotFound("Especialidade não encontrada.");
            }

            var existingAssociation = await _context.DoctorSpecialties
           .FirstOrDefaultAsync(ds => ds.UserId == user.Id);


            if (existingAssociation != null &&
                existingAssociation.Speciality != null &&
                existingAssociation.Speciality.Name.ToLower() == specialty_name.ToLower())
            {
                return BadRequest("O Médico já está associado a essa especialidade.");
            }

            var doctorSpecialty = new DoctorSpecialty
            {
                Id = existingAssociation.Id,
                UserId = user.Id,
                User = user,
                SpecialityId = specialty.Id,
                Speciality = specialty,
            };

            var newDoctorSpecility = await _doctorSpeciality.UpdateSpecialityAsync(doctorSpecialty.Id, doctorSpecialty);
            var doctorSpecialityDto = new DoctorSpecialityDto
            {
                UserName = newDoctorSpecility.User.UserName,
                SpecialityName = newDoctorSpecility.Speciality.Name
            };

            return Ok(doctorSpecialityDto);
        }

    }
}