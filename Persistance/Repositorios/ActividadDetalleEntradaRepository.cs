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
    public class ActividadDetalleEntradaRepository : IActividadDetalleEntradaRepository
    {
        private readonly IDataBase _dataBase;

        public ActividadDetalleEntradaRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SIDataBase));
        }

        public async Task<IEnumerable<ActividadDetalleEntradaEntity>> ListarActividadDetalleEntrada()
        {
            using (var cnx = _dataBase.GetConnection())
            {
                using (var reader = await cnx.ExecuteReaderAsync(
                     "[dbo].[usp_Listar_ActividadDetalleEntrada]",
                    commandType: CommandType.StoredProcedure))
                {
                    var result = new List<ActividadDetalleEntradaEntity>();

                    while (reader.Read())
                    {
                        var entity = new ActividadDetalleEntradaEntity()
                        {
                            Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo")),
                            CodigoDetalleEntrada = reader.IsDBNull(reader.GetOrdinal("CodigoDetalleEntrada")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoDetalleEntrada")),
                            CodigoActividad = reader.IsDBNull(reader.GetOrdinal("CodigoActividad")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoActividad")),
                        };

                        result.Add(entity);
                    }
                    return result;
                }
            }
        }



        public async Task<ActividadDetalleEntradaEntity> ObtenerActividadDetalleEntrada(int id)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", id);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_Obtener_ActividadDetalleEntrada]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    ActividadDetalleEntradaEntity result = null;

                    while (reader.Read())
                    {
                        result = new ActividadDetalleEntradaEntity();
                        result.Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo"));
                        result.CodigoDetalleEntrada = reader.IsDBNull(reader.GetOrdinal("CodigoDetalleEntrada")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoDetalleEntrada"));
                        result.CodigoActividad = reader.IsDBNull(reader.GetOrdinal("CodigoActividad")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoActividad"));
                    }

                    return result;
                }
            }
        }

        public async Task<int> CrearActividadDetalleEntrada(ActividadDetalleEntradaEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CodigoDetalleEntrada", variable.CodigoDetalleEntrada);
                parameters.Add("@CodigoActividad", variable.CodigoActividad);
                parameters.Add("@codigo", null, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                var result = await cnx.ExecuteAsync(
                    "[dbo].[usp_Registrar_ActividadDetalleEntrada]",
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

        public async Task ActualizarActividadDetalleEntrada(ActividadDetalleEntradaEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Codigo", variable.Codigo);
                parameters.Add("@CodigoDetalleEntrada", variable.CodigoDetalleEntrada);
                parameters.Add("@CodigoActividad", variable.CodigoActividad);

                var result = await cnx.ExecuteAsync(
                   "[dbo].[usp_Actualizar_ActividadDetalleEntrada]",
                   param: parameters,
                   commandType: CommandType.StoredProcedure);

            }
        }
    }
}

