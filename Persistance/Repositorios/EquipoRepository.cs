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
    public class EquipoRepository : IEquipoRepository
    {
        private readonly IDataBase _dataBase;

        public EquipoRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SIDataBase));
        }

        public async Task<IEnumerable<EquipoEntity>> ListarEquipo()
        {
            using (var cnx = _dataBase.GetConnection())
            {
                using (var reader = await cnx.ExecuteReaderAsync(
                     "[dbo].[usp_Listar_Equipo]",
                    commandType: CommandType.StoredProcedure))
                {
                    var result = new List<EquipoEntity>();

                    while (reader.Read())
                    {
                        var entity = new EquipoEntity()
                        {
                            Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo")),
                            CodigoPatrimonial = reader.IsDBNull(reader.GetOrdinal("CodigoPatrimonial")) ? default : reader.GetString(reader.GetOrdinal("CodigoPatrimonial")),
                            Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? default : reader.GetString(reader.GetOrdinal("Nombre")),
                            Marca = reader.IsDBNull(reader.GetOrdinal("Marca")) ? default : reader.GetString(reader.GetOrdinal("Marca")),
                            Modelo = reader.IsDBNull(reader.GetOrdinal("Modelo")) ? default : reader.GetString(reader.GetOrdinal("Modelo")),
                            NumSerie = reader.IsDBNull(reader.GetOrdinal("NumSerie")) ? default : reader.GetString(reader.GetOrdinal("NumSerie")),
                            Estado = reader.IsDBNull(reader.GetOrdinal("Estado")) ? default : reader.GetChar(reader.GetOrdinal("Estado")),
                            Caracteristicas = reader.IsDBNull(reader.GetOrdinal("Caracteristicas")) ? default : reader.GetString(reader.GetOrdinal("Caracteristicas")),
                            Vigente = reader.IsDBNull(reader.GetOrdinal("Vigente")) ? default : reader.GetBoolean(reader.GetOrdinal("Vigente")),
                            CodigoAmbiente = reader.IsDBNull(reader.GetOrdinal("CodigoAmbiente")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoAmbiente")),

                        };

                        result.Add(entity);
                    }
                    return result;
                }
            }
        }
    }
}
