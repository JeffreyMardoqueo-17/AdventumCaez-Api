using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AdventumCaez_API_DAL; //
using AdventumCaez_API_BL.modules;

namespace AdventumCaez_API_BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services, string connectionString)
        {
            // ⬇️ REGISTRA ApplicationDbContext con EF Core usando la cadena de conexión
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Llama a los módulos que registran los repositorios y servicios
            services.AddPaymentTypeServices();

            return services;
        }
    }
}
