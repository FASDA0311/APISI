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
    public class ActividadRepository : IActividadRepository
    {
        private readonly IDataBase _dataBase;

        public ActividadRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SIDataBase));
        }

        public async Task<IEnumerable<ActividadEntity>> ListarActividad()
        {
            using (var cnx = _dataBase.GetConnection())
            {
                using (var reader = await cnx.ExecuteReaderAsync(
                     "[dbo].[usp_Listar_Actividad]",
                    commandType: CommandType.StoredProcedure))
                {
                    var result = new List<ActividadEntity>();

                    while (reader.Read())
                    {
                        var entity = new ActividadEntity()
                        {
                            Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo")),
                            Fecha = reader.IsDBNull(reader.GetOrdinal("Fecha")) ? default: reader.GetDateTime(reader.GetOrdinal("Fecha")),
                            Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? default : reader.GetString(reader.GetOrdinal("Nombre")),
                            Estado = reader.IsDBNull(reader.GetOrdinal("Estado")) ? default : reader.GetChar(reader.GetOrdinal("Estado")),
                            CodigoDesarrollo = reader.IsDBNull(reader.GetOrdinal("CodigoDesarrollo")) ? default: reader.GetInt32(reader.GetOrdinal("CodigoDesarrollo")),
                        };

                        result.Add(entity);
                    }
                    return result;
                }
            }
        }



        public async Task<ActividadEntity> ObtenerActividad(int id)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", id);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_Obtener_Actividad]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    ActividadEntity result = null;

                    while (reader.Read())
                    {
                        result = new ActividadEntity();
                        result.Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo"));
                        result.Fecha = reader.IsDBNull(reader.GetOrdinal("Fecha")) ? default : reader.GetDateTime(reader.GetOrdinal("Fecha"));
                        result.Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? default : reader.GetString(reader.GetOrdinal("Nombre"));
                        result.Estado = reader.IsDBNull(reader.GetOrdinal("Estado")) ? default : reader.GetChar(reader.GetOrdinal("Estado"));
                        result.CodigoDesarrollo = reader.IsDBNull(reader.GetOrdinal("CodigoDesarrollo")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoDesarrollo"));
                        }

                    return result;
                }
            }
        }

        public async Task<int> CrearActividad(ActividadEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@fecha", variable.Fecha);
                parameters.Add("@nombre", variable.Nombre);
                parameters.Add("@Estado", variable.Estado);
                parameters.Add("@CodigoDesarrollo", variable.CodigoDesarrollo);
                parameters.Add("@codigo", null, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                var result = await cnx.ExecuteAsync(
                    "[dbo].[usp_Registrar_Actividad]",
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

        public async Task ActualizarActividad(ActividadEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", variable.Codigo);
                parameters.Add("@fecha", variable.Fecha);
                parameters.Add("@nombre", variable.Nombre);
                parameters.Add("@Estado", variable.Estado);
                parameters.Add("@CodigoDesarrollo", variable.CodigoDesarrollo);

                var result = await cnx.ExecuteAsync(
                   "[dbo].[usp_Actualizar_Actividad]",
                   param: parameters,
                   commandType: CommandType.StoredProcedure);

            }
        }
    }
}

