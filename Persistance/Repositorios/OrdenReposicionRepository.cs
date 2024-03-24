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
    public class OrdenReposicionRepository : IOrdenReposicionRepository
    {
        private readonly IDataBase _dataBase;

        public OrdenReposicionRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SIDataBase));
        }

        public async Task<IEnumerable<OrdenReposicionEntity>> ListarOrdenReposicion()
        {
            using (var cnx = _dataBase.GetConnection())
            {
                using (var reader = await cnx.ExecuteReaderAsync(
                     "[dbo].[usp_Listar_OrdenReposicion]",
                    commandType: CommandType.StoredProcedure))
                {
                    var result = new List<OrdenReposicionEntity>();

                    while (reader.Read())
                    {
                        var entity = new OrdenReposicionEntity()
                        {
                            Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo")),
                            Fecha = reader.IsDBNull(reader.GetOrdinal("Fecha")) ? default : reader.GetDateTime(reader.GetOrdinal("Fecha")),
                            Total = reader.IsDBNull(reader.GetOrdinal("Total")) ? default : reader.GetString(reader.GetOrdinal("Total")),
                            CodigoPersonalSoporte = reader.IsDBNull(reader.GetOrdinal("CodigoPersonalSoporte")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoPersonalSoporte")),
                            Vigente = reader.IsDBNull(reader.GetOrdinal("Vigente")) ? default : reader.GetBoolean(reader.GetOrdinal("Vigente"))
                        };

                        result.Add(entity);
                    }
                    return result;
                }
            }
        }



        public async Task<OrdenReposicionEntity> ObtenerOrdenReposicion(int id)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", id);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_Obtener_OrdenReposicion]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    OrdenReposicionEntity result = null;

                    while (reader.Read())
                    {
                        result = new OrdenReposicionEntity();
                        result.Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo"));
                        result.Fecha = reader.IsDBNull(reader.GetOrdinal("Fecha")) ? default : reader.GetDateTime(reader.GetOrdinal("Fecha"));
                        result.Total = reader.IsDBNull(reader.GetOrdinal("Total")) ? default : reader.GetString(reader.GetOrdinal("Total"));
                        result.CodigoPersonalSoporte = reader.IsDBNull(reader.GetOrdinal("CodigoPersonalSoporte")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoPersonalSoporte"));
                        result.Vigente = reader.IsDBNull(reader.GetOrdinal("Vigente")) ? default : reader.GetBoolean(reader.GetOrdinal("Vigente"));
                        }

                    return result;
                }
            }
        }

        public async Task<int> CrearOrdenReposicion(OrdenReposicionEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@fecha", variable.Fecha);
                parameters.Add("@total", variable.Total);
                parameters.Add("@codigopersonalsoporte", variable.CodigoPersonalSoporte);
                parameters.Add("@codigo", null, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                var result = await cnx.ExecuteAsync(
                    "[dbo].[usp_Registrar_OrdenReposicion]",
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

        public async Task ActualizarOrdenReposicion(OrdenReposicionEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", variable.Codigo);
                parameters.Add("@fecha", variable.Fecha);
                parameters.Add("@total", variable.Total);
                parameters.Add("@vigente", variable.Vigente);
                parameters.Add("@codigopersonalsoporte", variable.CodigoPersonalSoporte);

                var result = await cnx.ExecuteAsync(
                   "[dbo].[usp_Actualizar_OrdenReposicion]",
                   param: parameters,
                   commandType: CommandType.StoredProcedure);

            }
        }
    }
}

