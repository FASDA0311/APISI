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
    public class SalidaRepository : ISalidaRepository
    {
        private readonly IDataBase _dataBase;

        public SalidaRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SIDataBase));
        }

        public async Task<IEnumerable<SalidaEntity>> ListarSalida()
        {
            using (var cnx = _dataBase.GetConnection())
            {
                using (var reader = await cnx.ExecuteReaderAsync(
                     "[dbo].[usp_Listar_Salida]",
                    commandType: CommandType.StoredProcedure))
                {
                    var result = new List<SalidaEntity>();

                    while (reader.Read())
                    {
                        var entity = new SalidaEntity()
                        {
                            Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo")),
                            Fecha = reader.IsDBNull(reader.GetOrdinal("Fecha")) ? default : reader.GetDateTime(reader.GetOrdinal("Fecha")),
                            Observacion = reader.IsDBNull(reader.GetOrdinal("Observacion")) ? default : reader.GetString(reader.GetOrdinal("Observacion")),
                            Vigente = reader.IsDBNull(reader.GetOrdinal("Vigente")) ? default : reader.GetBoolean(reader.GetOrdinal("Vigente")),
                            CodigoDesarrollo = reader.IsDBNull(reader.GetOrdinal("CodigoDesarrollo")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoDesarrollo")),
                            CodigoPersonalSoporte = reader.IsDBNull(reader.GetOrdinal("CodigoPersonalSoporte")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoPersonalSoporte")),
                            CodigoResponsable = reader.IsDBNull(reader.GetOrdinal("CodigoResponsable")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoResponsable"))
                        };

                        result.Add(entity);
                    }
                    return result;
                }
            }
        }



        public async Task<SalidaEntity> ObtenerSalida(int id)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", id);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_Obtener_Salida]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    SalidaEntity result = null;

                    while (reader.Read())
                    {
                        result = new SalidaEntity();
                        result.Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo"));
                        result.Fecha = reader.IsDBNull(reader.GetOrdinal("Fecha")) ? default : reader.GetDateTime(reader.GetOrdinal("Fecha"));
                        result.Observacion = reader.IsDBNull(reader.GetOrdinal("Observacion")) ? default : reader.GetString(reader.GetOrdinal("Observacion"));
                        result.Vigente = reader.IsDBNull(reader.GetOrdinal("Vigente")) ? default : reader.GetBoolean(reader.GetOrdinal("Vigente"));
                        result.CodigoDesarrollo = reader.IsDBNull(reader.GetOrdinal("CodigoDesarrollo")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoDesarrollo"));
                        result.CodigoPersonalSoporte = reader.IsDBNull(reader.GetOrdinal("CodigoPersonalSoporte")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoPersonalSoporte"));
                        result.CodigoResponsable = reader.IsDBNull(reader.GetOrdinal("CodigoResponsable")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoResponsable"));
                    }

                    return result;
                }
            }
        }

        public async Task<int> CrearSalida(SalidaEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@fecha", variable.Fecha);
                parameters.Add("@observacion", variable.Observacion);
                parameters.Add("@codigodesarrollo", variable.CodigoDesarrollo);
                parameters.Add("@codigopersonalsoporte", variable.CodigoPersonalSoporte);
                parameters.Add("@codigoresponsable", variable.CodigoResponsable);
                parameters.Add("@codigo", null, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                var result = await cnx.ExecuteAsync(
                    "[dbo].[usp_Registrar_Salida]",
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

        public async Task ActualizarSalida(SalidaEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", variable.Codigo);
                parameters.Add("@fecha", variable.Fecha);
                parameters.Add("@observacion", variable.Observacion);
                parameters.Add("@vigente", variable.Vigente);
                parameters.Add("@codigodesarrollo", variable.CodigoDesarrollo);
                parameters.Add("@codigopersonalsoporte", variable.CodigoPersonalSoporte);
                parameters.Add("@codigoresponsable", variable.CodigoResponsable);

                var result = await cnx.ExecuteAsync(
                   "[dbo].[usp_Actualizar_Salida]",
                   param: parameters,
                   commandType: CommandType.StoredProcedure);

            }
        }
    }
}

