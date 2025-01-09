namespace MediSchedApi.Dtos.ConsultationReport
{
    public class ConsultationReportDto {
         public int Id { get; set; }
        public string UserName { get; set; }
        public string Specialty { get; set; }
        public int ConsultationCount { get; set; }
        public DateTime ReportDate { get; set; }
    }
}