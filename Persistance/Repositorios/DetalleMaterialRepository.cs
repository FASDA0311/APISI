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
    public class DetalleMaterialRepository : IDetalleMaterialRepository
    {
        private readonly IDataBase _dataBase;

        public DetalleMaterialRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SIDataBase));
        }

        public async Task<IEnumerable<DetalleMaterialEntity>> ListarDetalleMaterial()
        {
            using (var cnx = _dataBase.GetConnection())
            {
                using (var reader = await cnx.ExecuteReaderAsync(
                     "[dbo].[usp_Listar_DetalleMaterial]",
                    commandType: CommandType.StoredProcedure))
                {
                    var result = new List<DetalleMaterialEntity>();

                    while (reader.Read())
                    {
                        var entity = new DetalleMaterialEntity()
                        {
                            Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo")),
                            CodigoMaterial = reader.IsDBNull(reader.GetOrdinal("CodigoMaterial")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoMaterial")),
                            CodigoActividad = reader.IsDBNull(reader.GetOrdinal("CodigoActividad")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoActividad"))
                        };

                        result.Add(entity);
                    }
                    return result;
                }
            }
        }



        public async Task<DetalleMaterialEntity> ObtenerDetalleMaterial(int id)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", id);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_Obtener_DetalleMaterial]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    DetalleMaterialEntity result = null;

                    while (reader.Read())
                    {
                        result = new DetalleMaterialEntity();
                        result.Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo"));
                        result.CodigoMaterial = reader.IsDBNull(reader.GetOrdinal("CodigoMaterial")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoMaterial"));
                        result.CodigoActividad = reader.IsDBNull(reader.GetOrdinal("CodigoActividad")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoActividad"));
                    }

                    return result;
                }
            }
        }

        public async Task<int> CrearDetalleMaterial(DetalleMaterialEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigomaterial", variable.CodigoMaterial);
                parameters.Add("@codigoactividad", variable.CodigoActividad);
                parameters.Add("@codigo", null, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                var result = await cnx.ExecuteAsync(
                    "[dbo].[usp_Registrar_DetalleMaterial]",
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

        public async Task ActualizarDetalleMaterial(DetalleMaterialEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", variable.Codigo);
                parameters.Add("@codigomaterial", variable.CodigoMaterial);
                parameters.Add("@codigoactividad", variable.CodigoActividad);

                var result = await cnx.ExecuteAsync(
                   "[dbo].[usp_Actualizar_DetalleMaterial]",
                   param: parameters,
                   commandType: CommandType.StoredProcedure);

            }
        }
    }
}

