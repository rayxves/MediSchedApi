using Microsoft.EntityFrameworkCore;

namespace MediSchedApi.Data
{
    public class ApplicationDBContext : DbContext
    {
         ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}


