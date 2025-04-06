using Microsoft.Extensions.DependencyInjection;
using AdventumCaez_API_BL.modules; // Importing the modules

namespace AdventumCaez_API_BL
{
    /// <summary>
    /// This static class is used to configure and register all the dependencies required by the Business Layer (BL).
    /// Here, we call the module registration methods for each entity (e.g., PaymentType, User, Order).
    /// 
    /// Esta clase estática se usa para configurar y registrar todas las dependencias necesarias para la Capa de Negocios (BL).
    /// Aquí llamamos a los métodos de registro de módulos para cada entidad (por ejemplo, PaymentType, User, Order).
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// This method is used to register all the services and dependencies for the BL and DAL in the Dependency Injection container.
        /// It is called from the UI layer (e.g., in Program.cs) to configure the services for the application.
        /// 
        /// Este método se usa para registrar todos los servicios y dependencias para la BL y DAL en el contenedor de Inyección de Dependencias.
        /// Se llama desde la capa UI (por ejemplo, en Program.cs) para configurar los servicios para la aplicación.
        /// </summary>
        /// <param name="services">The IServiceCollection where services will be added.</param>
        /// <param name="connectionString">The connection string for the database.</param>
        /// <returns>The updated IServiceCollection with all the services registered.</returns>
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services, string connectionString)
        {
            // Calling the module to register the PaymentType services
            services.AddPaymentTypeServices(); // Registers the services for PaymentType


            return services;
        }
    }
}
