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
    public class DetalleEntradaRepository : IDetalleEntradaRepository
    {
        private readonly IDataBase _dataBase;

        public DetalleEntradaRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SIDataBase));
        }

        public async Task<IEnumerable<DetalleEntradaEntity>> ListarDetalleEntrada()
        {
            using (var cnx = _dataBase.GetConnection())
            {
                using (var reader = await cnx.ExecuteReaderAsync(
                     "[dbo].[usp_Listar_DetalleEntrada]",
                    commandType: CommandType.StoredProcedure))
                {
                    var result = new List<DetalleEntradaEntity>();

                    while (reader.Read())
                    {
                        var entity = new DetalleEntradaEntity()
                        {
                            Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo")),
                            Observacion = reader.IsDBNull(reader.GetOrdinal("Observacion")) ? default : reader.GetString(reader.GetOrdinal("Observacion")),
                            Vigente = reader.IsDBNull(reader.GetOrdinal("Vigente")) ? default : reader.GetBoolean(reader.GetOrdinal("Vigente")),
                            CodigoEquipo = reader.IsDBNull(reader.GetOrdinal("CodigoEquipo")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoEquipo")),
                            CodigoEntrada = reader.IsDBNull(reader.GetOrdinal("CodigoEntrada")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoEntrada")),
                            CodigoSalida = reader.IsDBNull(reader.GetOrdinal("CodigoSalida")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoSalida"))
                        };

                        result.Add(entity);
                    }
                    return result;
                }
            }
        }



        public async Task<DetalleEntradaEntity> ObtenerDetalleEntrada(int id)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", id);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_Obtener_DetalleEntrada]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    DetalleEntradaEntity result = null;

                    while (reader.Read())
                    {
                        result = new DetalleEntradaEntity();
                        result.Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo"));
                        result.Observacion = reader.IsDBNull(reader.GetOrdinal("Observacion")) ? default : reader.GetString(reader.GetOrdinal("Observacion"));
                        result.Vigente = reader.IsDBNull(reader.GetOrdinal("Vigente")) ? default : reader.GetBoolean(reader.GetOrdinal("Vigente"));
                        result.CodigoEquipo = reader.IsDBNull(reader.GetOrdinal("CodigoEquipo")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoEquipo"));
                        result.CodigoEntrada = reader.IsDBNull(reader.GetOrdinal("CodigoEntrada")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoEntrada"));
                        result.CodigoSalida = reader.IsDBNull(reader.GetOrdinal("CodigoSalida")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoSalida"));
                        }

                    return result;
                }
            }
        }

        public async Task<int> CrearDetalleEntrada(DetalleEntradaEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@observacion", variable.Observacion);
                parameters.Add("@codigoequipo", variable.CodigoEquipo);
                parameters.Add("@codigoentrada", variable.CodigoEntrada);
                parameters.Add("@codigosalida", variable.CodigoSalida);
                parameters.Add("@codigo", null, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                var result = await cnx.ExecuteAsync(
                    "[dbo].[usp_Registrar_DetalleEntrada]",
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

        public async Task ActualizarDetalleEntrada(DetalleEntradaEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", variable.Codigo);
                parameters.Add("@observacion", variable.Observacion);
                parameters.Add("@vigente", variable.Vigente);
                parameters.Add("@codigoequipo", variable.CodigoEquipo);
                parameters.Add("@codigoentrada", variable.CodigoEntrada);
                parameters.Add("@codigosalida", variable.CodigoSalida);


                var result = await cnx.ExecuteAsync(
                   "[dbo].[usp_Actualizar_DetalleEntrada]",
                   param: parameters,
                   commandType: CommandType.StoredProcedure);

            }
        }
    }
}


