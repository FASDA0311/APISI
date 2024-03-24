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
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositorios
{
    public class DesarrolloRepository : IDesarrolloRepository
    {
        private readonly IDataBase _dataBase;

        public DesarrolloRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SIDataBase));
        }

        public async Task<IEnumerable<DesarrolloEntity>> ListarDesarrollo()
        {
            using (var cnx = _dataBase.GetConnection())
            {
                using (var reader = await cnx.ExecuteReaderAsync(
                     "[dbo].[usp_Listar_Desarrollo]",
                    commandType: CommandType.StoredProcedure))
                {
                    var result = new List<DesarrolloEntity>();

                    while (reader.Read())
                    {
                        var entity = new DesarrolloEntity()
                        {
                            Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo")),
                            FechaInicio = reader.IsDBNull(reader.GetOrdinal("FechaInicio")) ? default : reader.GetDateTime(reader.GetOrdinal("FechaInicio")),
                            FechaFinal = reader.IsDBNull(reader.GetOrdinal("FechaFinal")) ? default : reader.GetDateTime(reader.GetOrdinal("FechaFinal")),
                            Detalle = reader.IsDBNull(reader.GetOrdinal("Detalle")) ? default : reader.GetString(reader.GetOrdinal("Detalle")),
                            Estado = reader.IsDBNull(reader.GetOrdinal("Estado")) ? default : reader.GetChar(reader.GetOrdinal("Estado")),
                            Vigente = reader.IsDBNull(reader.GetOrdinal("Vigente")) ? default : reader.GetBoolean(reader.GetOrdinal("Vigente")),
                            CodigoEntrada = reader.IsDBNull(reader.GetOrdinal("CodigoEntrada")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoEntrada"))
                        };

                        result.Add(entity);
                    }
                    return result;
                }
            }
        }



        public async Task<DesarrolloEntity> ObtenerDesarrollo(int id)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", id);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_Obtener_Desarrollo]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    DesarrolloEntity result = null;

                    while (reader.Read())
                    {
                        result = new DesarrolloEntity();
                        result.Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo"));
                        result.FechaInicio = reader.IsDBNull(reader.GetOrdinal("FechaInicio")) ? default : reader.GetDateTime(reader.GetOrdinal("FechaInicio"));
                        result.FechaFinal = reader.IsDBNull(reader.GetOrdinal("FechaFinal")) ? default : reader.GetDateTime(reader.GetOrdinal("FechaFinal"));
                        result.Detalle = reader.IsDBNull(reader.GetOrdinal("Detalle")) ? default : reader.GetString(reader.GetOrdinal("Detalle"));
                        result.Estado = reader.IsDBNull(reader.GetOrdinal("Estado")) ? default : reader.GetChar(reader.GetOrdinal("Estado"));
                        result.Vigente = reader.IsDBNull(reader.GetOrdinal("Vigente")) ? default : reader.GetBoolean(reader.GetOrdinal("Vigente"));
                        result.CodigoEntrada = reader.IsDBNull(reader.GetOrdinal("CodigoEntrada")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoEntrada"));
                    }

                    return result;
                }
            }
        }

        public async Task<int> CrearDesarrollo(DesarrolloEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                
                parameters.Add("@fechainicio", variable.FechaInicio);
                parameters.Add("@fechafinal", variable.FechaFinal);
                parameters.Add("@detalle", variable.Detalle);
                parameters.Add("@estado", variable.Estado);
                parameters.Add("@codigo", null, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                var result = await cnx.ExecuteAsync(
                    "[dbo].[usp_Registrar_Desarrollo]",
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

        public async Task ActualizarDesarrollo(DesarrolloEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", variable.Codigo);
                parameters.Add("@fechainicio", variable.FechaInicio);
                parameters.Add("@fechafinal", variable.FechaFinal);
                parameters.Add("@detalle", variable.Detalle);
                parameters.Add("@estado", variable.Estado);
                parameters.Add("@vigente", variable.Vigente);

                var result = await cnx.ExecuteAsync(
                   "[dbo].[usp_Actualizar_Desarrollo]",
                   param: parameters,
                   commandType: CommandType.StoredProcedure);

            }
        }
    }
}

