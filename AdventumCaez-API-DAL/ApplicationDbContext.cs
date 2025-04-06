// En la capa DAL (Data Access Layer)
using AdventumCaez_API_EN;
using Microsoft.EntityFrameworkCore;

namespace AdventumCaez_API_DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //db set
        public DbSet<PaymentType> PaymentTypes {get; set;}
    }
}
