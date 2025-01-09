using MediSchedApi.DoctorSpeciality;
using MediSchedApi.Dtos.ConsultationReport;
using MediSchedApi.Interfaces;
using MediSchedApi.Mappers.ConsulationReportMapper;
using MediSchedApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediSchedApi.Controllers
{
    [Route("/consultation-report")]
    [ApiController]
    public class ConsultationReportController : ControllerBase
    {
        private readonly IConsultationReportRepository _consultationReportRepo;
        private readonly UserManager<User> _userManager;
        private readonly IConsultationRepository _consultationRepo;
        private readonly IDoctorSpeciality _doctorSpecialityRepo;
        public ConsultationReportController(IConsultationReportRepository conultationReportRepo, UserManager<User> userManager, IConsultationRepository consultationRepo, IDoctorSpeciality doctorSpecialityRepo)
        {
            _consultationReportRepo = conultationReportRepo;
            _userManager = userManager;
            _consultationRepo = consultationRepo;
            _doctorSpecialityRepo = doctorSpecialityRepo;
        }


        [Authorize(Roles = "Adm")]
        [HttpPost("add-report")]
        public async Task<IActionResult> AddReport(string userName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.UserName.ToLower() == userName.ToLower());

            if (user == null)
            {
                return BadRequest("Usuário não encontrado.");
            }

            var consultationReportExists = await _consultationReportRepo.GetAllConsultationReportByDoctor(user);

            if (consultationReportExists.Any())
            {
                return BadRequest("Relatório já foi criado para esse usuário.");
            }


            var doctorSpecialty = await _doctorSpecialityRepo.GetDoctorSpecialtyByUserId(user.Id);

            if (doctorSpecialty == null)
            {
                return BadRequest("Especialidade do médico não encontrada.");
            }


            var consultationByUser = await _consultationRepo.GetConsultationByUser(user);
            var consultationCount = consultationByUser.Count;

            var consultationReport = new ConsultationReport
            {
                MedicoId = user.Id,
                Medico = user,
                DoctorSpecialty = doctorSpecialty,
                ConsultationCount = consultationCount,
                ReportDate = DateTime.UtcNow
            };

            await _consultationReportRepo.AddToConsultationReportAsync(consultationReport);

            return Ok(consultationReport.ToConsultationReportDto());

        }

        [HttpGet("{speciality}")]
        public async Task<IActionResult> GetConsultationReportBySpeciality(string speciality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (speciality == null)
            {
                return BadRequest("Especialidade não fornecida.");
            }

            var consultationsReportsBySpeciality = await _consultationReportRepo.GetAllConsultationReportBySpeciality(speciality);

            var totalConsultations = consultationsReportsBySpeciality
            .GroupBy(cs => cs.MedicoId)
            .Select(g => new
            {
                MedicoId = g.Key,
                MedicoName = g.First().Medico.UserName,
                ConsulationCount = g.Sum(cs => cs.ConsultationCount)
            });

            var newConsultationReport = new ConsultationReportDtoBySpeciality
            {
                Specialty = speciality,
                ConsultationCount = totalConsultations.Sum(tc => tc.ConsulationCount),
                ReportDate = DateTime.UtcNow,
                DoctorReports = totalConsultations.Select(tc => new DoctorConsultationDto
                {
                    MedicoId = tc.MedicoId,
                    MedicoName = tc.MedicoName,
                    ConsultationCount = tc.ConsulationCount,
                }).ToList()
            };

            return Ok(newConsultationReport);

        }

    }
}