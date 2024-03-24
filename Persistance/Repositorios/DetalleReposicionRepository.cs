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
    public class DetalleReposicionRepository : IDetalleReposicionRepository
    {
        private readonly IDataBase _dataBase;

        public DetalleReposicionRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SIDataBase));
        }

        public async Task<IEnumerable<DetalleReposicionEntity>> ListarDetalleReposicion()
        {
            using (var cnx = _dataBase.GetConnection())
            {
                using (var reader = await cnx.ExecuteReaderAsync(
                     "[dbo].[usp_Listar_DetalleReposicion]",
                    commandType: CommandType.StoredProcedure))
                {
                    var result = new List<DetalleReposicionEntity>();

                    while (reader.Read())
                    {
                        var entity = new DetalleReposicionEntity()
                        {
                            Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo")),
                            Cantidad = reader.IsDBNull(reader.GetOrdinal("Cantidad")) ? default : reader.GetString(reader.GetOrdinal("Cantidad")),
                            PrecioUnitario = reader.IsDBNull(reader.GetOrdinal("PrecioUnitario")) ? default : reader.GetString(reader.GetOrdinal("PrecioUnitario")),
                            CodigoReposicion = reader.IsDBNull(reader.GetOrdinal("CodigoReposicion")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoReposicion")),
                            CodigoMaterial = reader.IsDBNull(reader.GetOrdinal("CodigoMaterial")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoMaterial")),
                            Vigente = reader.IsDBNull(reader.GetOrdinal("Vigente")) ? default : reader.GetBoolean(reader.GetOrdinal("Vigente"))
                        };

                        result.Add(entity);
                    }
                    return result;
                }
            }
        }



        public async Task<DetalleReposicionEntity> ObtenerDetalleReposicion(int id)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", id);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_Obtener_DetalleReposicion]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    DetalleReposicionEntity result = null;

                    while (reader.Read())
                    {
                        result = new DetalleReposicionEntity();
                        result.Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo"));
                        result.Cantidad = reader.IsDBNull(reader.GetOrdinal("Cantidad")) ? default : reader.GetString(reader.GetOrdinal("Cantidad"));
                        result.PrecioUnitario = reader.IsDBNull(reader.GetOrdinal("PrecioUnitario")) ? default : reader.GetString(reader.GetOrdinal("PrecioUnitario"));
                        result.CodigoReposicion = reader.IsDBNull(reader.GetOrdinal("CodigoReposicion")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoReposicion"));
                        result.CodigoMaterial = reader.IsDBNull(reader.GetOrdinal("CodigoMaterial")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoMaterial"));
                        result.Vigente = reader.IsDBNull(reader.GetOrdinal("Vigente")) ? default : reader.GetBoolean(reader.GetOrdinal("Vigente"));
                    }

                    return result;
                }
            }
        }

        public async Task<int> CrearDetalleReposicion(DetalleReposicionEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@cantidad", variable.Cantidad);
                parameters.Add("@preciounitario", variable.PrecioUnitario);
                parameters.Add("@codigoreposicion", variable.CodigoReposicion);
                parameters.Add("@codigomaterial", variable.CodigoMaterial);
                parameters.Add("@codigo", null, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                var result = await cnx.ExecuteAsync(
                    "[dbo].[usp_Registrar_DetalleReposicion]",
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

        public async Task ActualizarDetalleReposicion(DetalleReposicionEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", variable.Codigo);
                parameters.Add("@cantidad", variable.Cantidad);
                parameters.Add("@preciounitario", variable.PrecioUnitario);
                parameters.Add("@vigente", variable.Vigente);
                parameters.Add("@codigoreposicion", variable.CodigoReposicion);
                parameters.Add("@codigomaterial", variable.CodigoMaterial);

                var result = await cnx.ExecuteAsync(
                   "[dbo].[usp_Actualizar_DetalleReposicion]",
                   param: parameters,
                   commandType: CommandType.StoredProcedure);

            }
        }
    }
}

