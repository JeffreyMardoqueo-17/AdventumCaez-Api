using Microsoft.Extensions.DependencyInjection;
using AdventumCaez_API_DAL.interfaces.PaymentTypes; // Importing DAL interfaces
using AdventumCaez_API_DAL.repositories; // Importing DAL repositories
using AdventumCaez_API_BL.interfaces; // Importing BL interfaces
using AdventumCaez_API_BL.services; // Importing BL services

namespace AdventumCaez_API_BL.modules
{
    /// <summary>
    /// This class is used to register the services related to PaymentType in the dependency injection container.
    /// Here we register the repository and the service for the PaymentType entity.
    /// 
    /// Esta clase se usa para registrar los servicios relacionados con PaymentType en el contenedor de inyección de dependencias.
    /// Aquí registramos el repositorio y el servicio para la entidad PaymentType.
    /// </summary>
    public static class PaymentTypeServiceRegistration
    {
        /// <summary>
        /// Registers the services for the PaymentType entity, including the repository and the service.
        /// This method adds the dependencies to the service collection so they can be injected where needed.
        /// 
        /// Registra los servicios para la entidad PaymentType, incluyendo el repositorio y el servicio.
        /// Este método agrega las dependencias a la colección de servicios para que puedan ser inyectadas donde se necesiten.
        /// </summary>
        /// <param name="services">The IServiceCollection that contains all the services to be registered.</param>
        /// <returns>The updated IServiceCollection with the PaymentType services registered.</returns>
        public static IServiceCollection AddPaymentTypeServices(this IServiceCollection services)
        {
            services.AddScoped<IPaymentType, PaymentTypeRepository>(); // Registering the repository
            services.AddScoped<IPaymentTypeService, PaymentTypeService>(); // Registering the service

            return services;
        }
    }
}
