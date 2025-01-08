using System.Security.Claims;
using MediSchedApi.Interfaces;
using MediSchedApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MediSchedApi.Controllers
{
    [Route("/consultation")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationRepository _consultationRepo;
        private readonly IDoctorSpeciality _doctorSpeciality;

        public ConsultationController(IConsultationRepository consultationRepo, IDoctorSpeciality doctorSpeciality)
        {
            _consultationRepo = consultationRepo;
            _doctorSpeciality = doctorSpeciality;
        }

        [Authorize(Roles = "Paciente")]
        [HttpPost("add")]
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
                System.Globalization.DateTimeStyles.None, out DateTime consulationDate))
            {
                return BadRequest("Data da consulta não fornecida ou inválida. Use o formato dd-MM-yyyy HH:mm. Exemplo: '01-08-2025 18:00'.");
            }

            if (consulationDate == default)
            {
                return BadRequest("Data da consulta não fornecida ou inválida.");
            }

            if (consulationDate.Kind != DateTimeKind.Utc)
            {
                consulationDate = DateTime.SpecifyKind(consulationDate, DateTimeKind.Utc);
            }
            var doctorsSpecialty = await _doctorSpeciality.GetDoctorSpecialtyBySymptom(symptoms);

            if (!doctorsSpecialty.Any())
            {
                doctorsSpecialty = await _doctorSpeciality.GetAllDoctorSpecialtyGeral();

            }

            var consulationAtThisTime = await _consultationRepo.GetConsultationByDate(consulationDate);

            foreach (var doctor in doctorsSpecialty)
            {
                var consulationByUser = await _consultationRepo.GetConsultationByUser(doctor.User);
                var hasConflict = consulationAtThisTime.Any(ct => consulationByUser.Any(cu => cu.Id == ct.Id));

                if (!hasConflict)
                {
                    var userId = User.FindFirst("id")?.Value;

                    var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
                    if (string.IsNullOrEmpty(userEmail))
                    {
                        return BadRequest("Email do usuário não encontrado.");
                    }

                    if (string.IsNullOrEmpty(doctor.User.Email))
                    {
                        return BadRequest("Email do médico não encontrado.");
                    }

                    var consulationDateUtc = consulationDate.ToUniversalTime();

                    var consulation = new Consultation
                    {
                        PacienteId = userId,
                        MedicoId = doctor.User.Id,
                        Data = consulationDateUtc,
                        Status = "Agendada"
                    };
                    await _consultationRepo.AddToConsulationAsync(consulation);

                    var subject = "Nova consulta.";
                    var body = "Consulta agendada para o dia " + consulationDate.ToString("dd/MM/yyyy") + " às " + consulationDate.ToString("HH:mm") + ".";
                    await _consultationRepo.NotifierConsultation(doctor.User.Email, subject, body);
                    await _consultationRepo.NotifierConsultation(userEmail, subject, body);

                    return Ok("Consulta agendada com sucesso.");
                }
            }
            return NotFound("Nenhum médico disponível na data e hora especificadas.");
        }

        [HttpDelete]
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

