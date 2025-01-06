using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediSchedApi.Models
{
    public class Consultation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PacienteId { get; set; }
        public string MedicoId { get; set; }

        public virtual User Paciente { get; set; }
        public virtual User Medico { get; set; }
        
        public DateTime Data { get; set; }
        public string Status { get; set; }



    }
}