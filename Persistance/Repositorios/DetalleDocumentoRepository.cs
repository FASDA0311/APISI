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
    public class DetalleDocumentoRepository : IDetalleDocumentoRepository
    {
        private readonly IDataBase _dataBase;

        public DetalleDocumentoRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SIDataBase));
        }

        public async Task<IEnumerable<DetalleDocumentoEntity>> ListarDetalleDocumento()
        {
            using (var cnx = _dataBase.GetConnection())
            {
                using (var reader = await cnx.ExecuteReaderAsync(
                     "[dbo].[usp_Listar_DetalleDocumento]",
                    commandType: CommandType.StoredProcedure))
                {
                    var result = new List<DetalleDocumentoEntity>();

                    while (reader.Read())
                    {
                        var entity = new DetalleDocumentoEntity()
                        {
                            Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo")),
                            CodigoEquipo = reader.IsDBNull(reader.GetOrdinal("CodigoEquipo")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoEquipo")),
                            CodigoDocumento = reader.IsDBNull(reader.GetOrdinal("CodigoDocumento")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoDocumento")),
                        };

                        result.Add(entity);
                    }
                    return result;
                }
            }
        }



        public async Task<DetalleDocumentoEntity> ObtenerDetalleDocumento(int id)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", id);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_Obtener_DetalleDocumento]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    DetalleDocumentoEntity result = null;

                    while (reader.Read())
                    {
                        result = new DetalleDocumentoEntity();
                        result.Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo"));
                        result.CodigoEquipo = reader.IsDBNull(reader.GetOrdinal("CodigoEquipo")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoEquipo"));
                        result.CodigoDocumento = reader.IsDBNull(reader.GetOrdinal("CodigoDocumento")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoDocumento"));
        }

                    return result;
                }
            }
        }

        public async Task<int> CrearDetalleDocumento(DetalleDocumentoEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigoequipo.", variable.CodigoEquipo);
                parameters.Add("@codigodocumento", variable.CodigoDocumento);
                parameters.Add("@codigo", null, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                var result = await cnx.ExecuteAsync(
                    "[dbo].[usp_Registrar_DetalleDocumento]",
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

        public async Task ActualizarDetalleDocumento(DetalleDocumentoEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", variable.Codigo);
                parameters.Add("@codigoequipo.", variable.CodigoEquipo);
                parameters.Add("@codigodocumento", variable.CodigoDocumento);

                var result = await cnx.ExecuteAsync(
                   "[dbo].[usp_Actualizar_DetalleDocumento]",
                   param: parameters,
                   commandType: CommandType.StoredProcedure);

            }
        }
    }
}
