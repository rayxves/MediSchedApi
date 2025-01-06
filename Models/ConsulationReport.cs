using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediSchedApi.Models
{
    public class ConsulationReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MedicoId { get; set; }
        public string Status { get; set; } = string.Empty;
        public int ConsultationCount { get; set; }
        public DateTime ReportDate { get; set; }
    }
}