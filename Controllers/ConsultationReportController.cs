using MediSchedApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediSchedApi.Controllers
{
    [Route("/consultation-report")]
    [ApiController]
    public class ConsultationReportController : ControllerBase
    {
        private readonly IConsultationReportRepository _consultationReportRepo;
        public ConsultationReportController(IConsultationReportRepository conultationReportRepo)
        {
            _consultationReportRepo = conultationReportRepo;
        }

        // [HttpPost("add-report")]
        // public async Task<IActionResult> AddReport()
        // {
            
        // }
    }
}