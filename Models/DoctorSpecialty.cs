using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediSchedApi.Models
{
    public class DoctorSpecialty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; } = null!;

        public int SpecialityId { get; set; }
        public Specialty Speciality { get; set; } = null!;
    }
}