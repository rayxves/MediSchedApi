
using Microsoft.AspNetCore.Identity;

namespace MediSchedApi.Models
{

    public class User : IdentityUser
    {
        public string RoleId { get; set; }
        public Role Role { get; set; } = null!;

        public ICollection<DoctorSpecialty> DoctorSpecialties { get; set; } = new List<DoctorSpecialty>();
    }
}