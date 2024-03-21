
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
            return services;
        }
        
    }
}
