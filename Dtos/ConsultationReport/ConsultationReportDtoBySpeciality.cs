using MediSchedApi.DoctorSpeciality;

namespace MediSchedApi.Dtos.ConsultationReport
{
    public class ConsultationReportDtoBySpeciality
    {
        public int Id { get; set; }
        public string Specialty { get; set; }
        public int ConsultationCount { get; set; }
        public DateTime ReportDate { get; set; }
        public List<DoctorConsultationDto> DoctorReports { get; set; }
    }
}