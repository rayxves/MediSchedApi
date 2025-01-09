using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediSchedApi.Models
{
    public class ConsultationReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MedicoId { get; set; }
        public User Medico { get; set; }
        public int DoctorSpecialtyId { get; set; }
        public DoctorSpecialty DoctorSpecialty { get; set; }
        public int ConsultationCount { get; set; }
        public DateTime ReportDate { get; set; }
    }
}