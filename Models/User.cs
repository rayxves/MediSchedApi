
using Microsoft.AspNetCore.Identity;

namespace MediSchedApi.Models
{

    public class User : IdentityUser
    {
        public Role Role { get; set; } = null!;
        public string RoleId { get; set; }
        public ICollection<DoctorSpecialty> DoctorSpecialties { get; set; } = new List<DoctorSpecialty>();
    }
}