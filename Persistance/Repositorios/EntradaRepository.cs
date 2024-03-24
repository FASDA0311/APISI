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
    public class EntradaRepository : IEntradaRepository
    {
        private readonly IDataBase _dataBase;

        public EntradaRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SIDataBase));
        }

        public async Task<IEnumerable<EntradaEntity>> ListarEntrada()
        {
            using (var cnx = _dataBase.GetConnection())
            {
                using (var reader = await cnx.ExecuteReaderAsync(
                     "[dbo].[usp_Listar_Entrada]",
                    commandType: CommandType.StoredProcedure))
                {
                    var result = new List<EntradaEntity>();

                    while (reader.Read())
                    {
                        var entity = new EntradaEntity()
                        {
                            Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo")),
                            Fecha = reader.IsDBNull(reader.GetOrdinal("Fecha")) ? default : reader.GetDateTime(reader.GetOrdinal("Fecha")),
                            Motivo = reader.IsDBNull(reader.GetOrdinal("Motivo")) ? default : reader.GetString(reader.GetOrdinal("Motivo")),
                            NivelPrioridad = reader.IsDBNull(reader.GetOrdinal("NivelPrioridad")) ? default : reader.GetChar(reader.GetOrdinal("NivelPrioridad")),
                            Estado = reader.IsDBNull(reader.GetOrdinal("Estado")) ? default : reader.GetChar(reader.GetOrdinal("Estado")),
                            Vigente = reader.IsDBNull(reader.GetOrdinal("Vigente")) ? default : reader.GetBoolean(reader.GetOrdinal("Vigente")),
                            CodigoPersonalSoporte = reader.IsDBNull(reader.GetOrdinal("CodigoPersonalSoporte")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoPersonalSoporte")),
                            CodigoDocumento = reader.IsDBNull(reader.GetOrdinal("CodigoDocumento")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoDocumento")),
                            CodigoResponsable = reader.IsDBNull(reader.GetOrdinal("CodigoResponsable")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoResponsable"))
                        };

                        result.Add(entity);
                    }
                    return result;
                }
            }
        }



        public async Task<EntradaEntity> ObtenerEntrada(int id)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", id);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_Obtener_Entrada]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    EntradaEntity result = null;

                    while (reader.Read())
                    {
                        result = new EntradaEntity();
                        result.Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo"));
                        result.Fecha = reader.IsDBNull(reader.GetOrdinal("Fecha")) ? default : reader.GetDateTime(reader.GetOrdinal("Fecha"));
                        result.Motivo = reader.IsDBNull(reader.GetOrdinal("Motivo")) ? default : reader.GetString(reader.GetOrdinal("Motivo"));
                        result.NivelPrioridad = reader.IsDBNull(reader.GetOrdinal("NivelPrioridad")) ? default : reader.GetChar(reader.GetOrdinal("NivelPrioridad"));
                        result.Estado = reader.IsDBNull(reader.GetOrdinal("Estado")) ? default : reader.GetChar(reader.GetOrdinal("Estado"));
                        result.Vigente = reader.IsDBNull(reader.GetOrdinal("Vigente")) ? default : reader.GetBoolean(reader.GetOrdinal("Vigente"));
                        result.CodigoPersonalSoporte = reader.IsDBNull(reader.GetOrdinal("CodigoPersonalSoporte")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoPersonalSoporte"));
                        result.CodigoDocumento = reader.IsDBNull(reader.GetOrdinal("CodigoDocumento")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoDocumento"));
                        result.CodigoResponsable = reader.IsDBNull(reader.GetOrdinal("CodigoResponsable")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoResponsable"));
                    }

                    return result;
                }
            }
        }

        public async Task<int> CrearEntrada(EntradaEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@fecha", variable.Fecha);
                parameters.Add("@motivo", variable.Motivo);
                parameters.Add("@nivelprioridad", variable.NivelPrioridad);
                parameters.Add("@estado", variable.Estado);
                parameters.Add("@codigopersonalsoporte", variable.CodigoPersonalSoporte);
                parameters.Add("@codigodocumento", variable.CodigoDocumento);
                parameters.Add("@codigoresponsable", variable.CodigoResponsable);
                parameters.Add("@codigo", null, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                var result = await cnx.ExecuteAsync(
                    "[dbo].[usp_Registrar_Entrada]",
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

        public async Task ActualizarEntrada(EntradaEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", variable.Codigo);
                parameters.Add("@fecha", variable.Fecha);
                parameters.Add("@motivo", variable.Motivo);
                parameters.Add("@nivelprioridad", variable.NivelPrioridad);
                parameters.Add("@estado", variable.Estado);
                parameters.Add("@vigente", variable.Vigente);
                parameters.Add("@codigopersonalsoporte", variable.CodigoPersonalSoporte);
                parameters.Add("@codigodocumento", variable.CodigoDocumento);
                parameters.Add("@codigoresponsable", variable.CodigoResponsable);


                var result = await cnx.ExecuteAsync(
                   "[dbo].[usp_Actualizar_Entrada]",
                   param: parameters,
                   commandType: CommandType.StoredProcedure);

            }
        }
    }
}

