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
    public class MaterialRepository : IMaterialRepository
    {
        private readonly IDataBase _dataBase;

        public MaterialRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SIDataBase));
        }

        public async Task<IEnumerable<MaterialEntity>> ListarMaterial()
        {
            using (var cnx = _dataBase.GetConnection())
            {
                using (var reader = await cnx.ExecuteReaderAsync(
                     "[dbo].[usp_Listar_Material]",
                    commandType: CommandType.StoredProcedure))
                {
                    var result = new List<MaterialEntity>();

                    while (reader.Read())
                    {
                        var entity = new MaterialEntity()
                        {
                            Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo")),
                            Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? default : reader.GetString(reader.GetOrdinal("Nombre")),
                            Cantidad = reader.IsDBNull(reader.GetOrdinal("Cantidad")) ? default : reader.GetInt32(reader.GetOrdinal("Cantidad")),
                            TipoProductoCodigo = reader.IsDBNull(reader.GetOrdinal("TipoProducto_Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("TipoProducto_Codigo")),
                            Vigente = reader.IsDBNull(reader.GetOrdinal("Vigente")) ? default : reader.GetBoolean(reader.GetOrdinal("Vigente"))
                        };

                        result.Add(entity);
                    }
                    return result;
                }
            }
        }



        public async Task<MaterialEntity> ObtenerMaterial(int id)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", id);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_Obtener_Material]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    MaterialEntity result = null;

                    while (reader.Read())
                    {
                        result = new MaterialEntity();
                        result.Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo"));
                        result.Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? default : reader.GetString(reader.GetOrdinal("Nombre"));
                        result.Cantidad = reader.IsDBNull(reader.GetOrdinal("Cantidad")) ? default : reader.GetInt32(reader.GetOrdinal("Cantidad"));
                        result.TipoProductoCodigo = reader.IsDBNull(reader.GetOrdinal("TipoProducto_Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("TipoProducto_Codigo"));
                        result.Vigente = reader.IsDBNull(reader.GetOrdinal("Vigente")) ? default : reader.GetBoolean(reader.GetOrdinal("Vigente"));
                        }

                    return result;
                }
            }
        }

        public async Task<int> CrearMaterial(MaterialEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nombre", variable.Nombre);
                parameters.Add("@cantidad", variable.Cantidad);
                parameters.Add("@tipoproductocodigo", variable.TipoProductoCodigo);
                parameters.Add("@codigo", null, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                var result = await cnx.ExecuteAsync(
                    "[dbo].[usp_Registrar_Material]",
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

        public async Task ActualizarMaterial(MaterialEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", variable.Codigo);
                parameters.Add("@nombre", variable.Nombre);
                parameters.Add("@cantidad", variable.Cantidad);
                parameters.Add("@vigente", variable.Vigente);
                parameters.Add("@tipoproductocodigo", variable.TipoProductoCodigo);

                var result = await cnx.ExecuteAsync(
                   "[dbo].[usp_Actualizar_Material]",
                   param: parameters,
                   commandType: CommandType.StoredProcedure);

            }
        }
    }
}

