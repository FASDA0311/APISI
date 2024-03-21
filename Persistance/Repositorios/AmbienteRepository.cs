using Application.Common.Interfaces;
using Application.Common.Interfaces.Repositorios;
using Dapper;
using Domain.Entidades;
using Microsoft.Extensions.DependencyInjection;
using Persistance.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositorios
{
    public class AmbienteRepository : IAmbienteRepository
    {
        private readonly IDataBase _dataBase;

        public AmbienteRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SIDataBase));
        }

        public async Task<IEnumerable<AmbienteEntity>> ListarAmbiente()
        {
            using (var cnx = _dataBase.GetConnection())
            {
                using (var reader = await cnx.ExecuteReaderAsync(
                     "[dbo].[usp_Listar_Ambiente]",
                    commandType: CommandType.StoredProcedure))
                {
                    var result = new List<AmbienteEntity>();

                    while (reader.Read())
                    {
                        var entity = new AmbienteEntity()
                        {
                            Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo")),
                            Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? default : reader.GetString(reader.GetOrdinal("Nombre")),
                            Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? default : reader.GetString(reader.GetOrdinal("Descripcion")),
                            Vigente = reader.IsDBNull(reader.GetOrdinal("Vigente")) ? default : reader.GetBoolean(reader.GetOrdinal("Vigente")),
                        };

                        result.Add(entity);
                    }
                    return result;
                }
            }
        }
    }
}
