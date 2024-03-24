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
using System.Net;
using System.Reflection.PortableExecutable;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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



        public async Task<EquipoEntity> ObtenerEquipo(int id)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", id);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_Obtener_Equipo]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    EquipoEntity result = null;

                    while (reader.Read())
                    {
                        result = new EquipoEntity();
                        result.Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo"));
                        result.CodigoPatrimonial = reader.IsDBNull(reader.GetOrdinal("CodigoPatrimonial")) ? default : reader.GetString(reader.GetOrdinal("CodigoPatrimonial"));
                        result.Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? default : reader.GetString(reader.GetOrdinal("Nombre"));
                        result.Marca = reader.IsDBNull(reader.GetOrdinal("Marca")) ? default : reader.GetString(reader.GetOrdinal("Marca"));
                        result.Modelo = reader.IsDBNull(reader.GetOrdinal("Modelo")) ? default : reader.GetString(reader.GetOrdinal("Modelo"));
                        result.NumSerie = reader.IsDBNull(reader.GetOrdinal("NumSerie")) ? default : reader.GetString(reader.GetOrdinal("NumSerie"));
                        result.Estado = reader.IsDBNull(reader.GetOrdinal("Estado")) ? default : reader.GetChar(reader.GetOrdinal("Estado"));
                        result.Caracteristicas = reader.IsDBNull(reader.GetOrdinal("Caracteristicas")) ? default : reader.GetString(reader.GetOrdinal("Caracteristicas"));
                        result.Vigente = reader.IsDBNull(reader.GetOrdinal("Vigente")) ? default : reader.GetBoolean(reader.GetOrdinal("Vigente"));
                        result.CodigoAmbiente = reader.IsDBNull(reader.GetOrdinal("CodigoAmbiente")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoAmbiente"));

                    }

                    return result;
                }
            }
        }

        public async Task<int> CrearEquipo(EquipoEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigopatrimonial", variable.CodigoPatrimonial);
                parameters.Add("@nombre", variable.Nombre);
                parameters.Add("@marca", variable.Marca);
                parameters.Add("@modelo", variable.Modelo);
                parameters.Add("@numserie", variable.NumSerie);
                parameters.Add("@estado", variable.Estado);
                parameters.Add("@caracteristicas", variable.Caracteristicas);
                parameters.Add("@codigoambiente", variable.CodigoAmbiente);
                parameters.Add("@codigo", null, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                var result = await cnx.ExecuteAsync(
                    "[dbo].[usp_Registrar_Equipo]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);
                try
                {
                    var Id = parameters.Get<int>("@codigo");

                    return Id;

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public async Task ActualizarEquipo(EquipoEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", variable.Codigo);
                parameters.Add("@codigopatrimonial", variable.CodigoPatrimonial);
                parameters.Add("@nombre", variable.Nombre);
                parameters.Add("@marca", variable.Marca);
                parameters.Add("@modelo", variable.Modelo);
                parameters.Add("@numserie", variable.NumSerie);
                parameters.Add("@estado", variable.Estado);
                parameters.Add("@caracteristicas", variable.Caracteristicas);
                parameters.Add("@vigente", variable.Vigente);
                parameters.Add("@codigoambiente", variable.CodigoAmbiente);

                var result = await cnx.ExecuteAsync(
                   "[dbo].[usp_Actualizar_Equipo]",
                   param: parameters,
                   commandType: CommandType.StoredProcedure);

            }
        }
    }
}
