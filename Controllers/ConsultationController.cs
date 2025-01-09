using System.Security.Claims;
using MediSchedApi.Interfaces;
using MediSchedApi.Mappers.ConsultationMapper;
using MediSchedApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MediSchedApi.Controllers
{
    [Route("/consultation")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationRepository _consultationRepo;
        private readonly IDoctorSpeciality _doctorSpeciality;
        private readonly UserManager<User> _userManager;

        public ConsultationController(IConsultationRepository consultationRepo, IDoctorSpeciality doctorSpeciality, UserManager<User> userManager)
        {
            _consultationRepo = consultationRepo;
            _doctorSpeciality = doctorSpeciality;
            _userManager = userManager;
        }

        [Authorize(Roles = "Adm")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var consultation = await _consultationRepo.GetAllConsultations();
            if (!consultation.Any())
            {
                return NotFound("Nenhuma consulta encontrada.");
            }

            var consultationsDto = consultation.Select(c => c.ToConsultationDto()).ToList();
            return Ok(consultationsDto);
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetConsultationByUser(string username)
        {
            var user = await _userManager.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.UserName == username);

            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            var consultations = await _consultationRepo.GetConsultationByUser(user);

            if (consultations == null || !consultations.Any())
            {
                return NotFound("Consultas não encontradas.");
            }

            var consultationsDto = consultations.Select(c => c.ToConsultationDtoByUser()).ToList();

            return Ok(consultationsDto);
        }

        [Authorize(Roles = "Paciente")]
        [HttpPost("schedule")]
        public async Task<IActionResult> AddConsulation(string symptoms, string consultationDate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(symptoms))
            {
                return BadRequest("Sintomas não fornecidos.");
            }


            if (!DateTime.TryParseExact(consultationDate, "dd-MM-yyyy HH:mm",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime consultationDateUtc))
            {
                return BadRequest("Data da consulta não fornecida ou inválida. Use o formato dd-MM-yyyy HH:mm. Exemplo: '01-08-2025 18:00'.");
            }

            if (consultationDateUtc.Kind != DateTimeKind.Utc)
            {
                consultationDateUtc = DateTime.SpecifyKind(consultationDateUtc, DateTimeKind.Utc);
            }

            if (consultationDateUtc < DateTime.UtcNow)
            {
                return BadRequest("Não é possível agendar uma consulta para uma data passada.");
            }

            var doctorsSpecialty = await _doctorSpeciality.GetDoctorSpecialtyBySymptom(symptoms);

            if (!doctorsSpecialty.Any())
            {
                doctorsSpecialty = await _doctorSpeciality.GetAllDoctorSpecialtyGeral();

            }

            var consulationAtThisTime = await _consultationRepo.GetConsultationByDate(consultationDateUtc);

            foreach (var doctor in doctorsSpecialty)
            {
                var consulationByUser = await _consultationRepo.GetConsultationByUser(doctor.User);
                var hasConflict = consulationAtThisTime.Any(ct => consulationByUser.Any(cu => cu.Id == ct.Id));

                if (!hasConflict)
                {
                    var userId = User.FindFirst("id")?.Value;
                    var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
                    var userName = User.FindFirst("name")?.Value;

                    if (string.IsNullOrEmpty(userEmail))
                    {
                        return BadRequest("Email do usuário não encontrado.");
                    }

                    if (string.IsNullOrEmpty(doctor.User.Email))
                    {
                        return BadRequest("Email do médico não encontrado.");
                    }

                    var consulationDateUtc = consultationDateUtc.ToUniversalTime();

                    var consulation = new Consultation
                    {
                        PacienteId = userId,
                        MedicoId = doctor.User.Id,
                        Data = consulationDateUtc,
                        Status = "Agendada"
                    };
                    await _consultationRepo.AddToConsulationAsync(consulation);

                    await _consultationRepo.NotifierConsultation(userName, doctor.User.UserName, doctor.User.Email, consulationDateUtc);
                    await _consultationRepo.NotifierConsultation(userName, doctor.User.UserName, userEmail, consulationDateUtc);

                    return Ok("Consulta agendada com sucesso.");
                }
            }
            return NotFound("Nenhum médico disponível na data e hora especificadas.");
        }

        [HttpDelete("cancel")]
        public async Task<ActionResult> DeleteConsultation(int consultationId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var consultation = await _consultationRepo.GetConsultationById(consultationId);

            if (consultation == null)
            {
                return NotFound("Consulta não encontrada.");
            }

            if (consultation.Data < DateTime.UtcNow)
            {
                return BadRequest("Não é possível cancelar uma consulta que já ocorreu.");
            }

            await _consultationRepo.DeleteConsultationAsync(consultation);
            return NoContent();
        }
    }
}

