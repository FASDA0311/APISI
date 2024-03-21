using Application;
using Persistance;

namespace SistemaInformatico.API.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection InjectarDependencia(this IServiceCollection services, IConfiguration configuration)
        {
            var conexion = configuration.GetConnectionString("cadenaSQL");
            services.AddPersistenceLayer(conexion);
            services.AddApplicationLayer();
            return services;
        }
    }
}
