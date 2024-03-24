
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Persistance.DataBase;
using Persistance.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public static class DependencyInjection 
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IDataBase>(sp => new SIDataBase(connectionString));
            services.AddTransient<IPersonalSoporteRepository, PersonalSoporteRepository>();
            services.AddTransient<IAmbienteRepository, AmbienteRepository>();
            services.AddTransient<IDocumentoRepository, DocumentoRepository>();
            services.AddTransient<IDetalleDocumentoRepository, DetalleDocumentoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IEquipoRepository, EquipoRepository>();
            services.AddTransient<IResponsableRepository, ResponsableRepository>();
            services.AddTransient<ITipoMaterialRepository, TipoMaterialRepository>();
            services.AddTransient<IMaterialRepository, MaterialRepository>();
            services.AddTransient<IOrdenReposicionRepository, OrdenReposicionRepository>();
            services.AddTransient<IDetalleReposicionRepository, DetalleReposicionRepository>();
            services.AddTransient<IEntradaRepository, EntradaRepository>();
            services.AddTransient<IDesarrolloRepository, DesarrolloRepository>();
            services.AddTransient<ISalidaRepository, SalidaRepository>();
            services.AddTransient<IDetalleEntradaRepository, DetalleEntradaRepository>();
            services.AddTransient<IActividadRepository, ActividadRepository>();
            services.AddTransient<IDetalleMaterialRepository, DetalleMaterialRepository>();
            services.AddTransient<IPersonalDesarrolloRepository, PersonalDesarrolloRepository>();
            services.AddTransient<IActividadDetalleEntradaRepository, ActividadDetalleEntradaRepository>();
            return services;
        }
        
    }
}
