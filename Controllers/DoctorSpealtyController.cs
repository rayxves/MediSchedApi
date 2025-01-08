

using MediSchedApi.Data;
using MediSchedApi.Models;
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
        public DoctorSpealtyController(UserManager<User> userManager, ApplicationDBContext context)
        {
            _context = context;
            _userManager = userManager;
        }

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
            var specialty = await _context.Specialties.FirstOrDefaultAsync(s => s.Name == specialty_name);
            if (specialty == null)
            {
                return NotFound("Especialidade não encontrada.");
            }

            var existingAssociation = await _context.DoctorSpecialties
           .FirstOrDefaultAsync(ds => ds.UserId == user.Id && ds.SpecialtyId == specialty.Id);

            if (existingAssociation != null)
            {
                return BadRequest("O Médico já está associado a essa especialidade.");
            }

            var doctorSpecialty = new DoctorSpecialty
            {
                UserId = user.Id,
                SpecialtyId = specialty.Id
            };

            _context.DoctorSpecialties.Add(doctorSpecialty);
            await _context.SaveChangesAsync();

            return Ok("Associação realizada com sucesso.");
        }

    }
}