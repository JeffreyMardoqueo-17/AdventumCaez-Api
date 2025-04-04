// En la capa DAL (Data Access Layer)
using Microsoft.EntityFrameworkCore;

namespace AdventumCaez_API_DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
