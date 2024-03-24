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
    public class DocumentoRepository : IDocumentoRepository
    {
        private readonly IDataBase _dataBase;

        public DocumentoRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SIDataBase));
        }

        public async Task<IEnumerable<DocumentoEntity>> ListarDocumento()
        {
            using (var cnx = _dataBase.GetConnection())
            {
                using (var reader = await cnx.ExecuteReaderAsync(
                     "[dbo].[usp_Listar_Documento]",
                    commandType: CommandType.StoredProcedure))
                {
                    var result = new List<DocumentoEntity>();

                    while (reader.Read())
                    {
                        var entity = new DocumentoEntity()
                        {
                            Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo")),
                            Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? default : reader.GetString(reader.GetOrdinal("Nombre")),
                            Fecha = reader.IsDBNull(reader.GetOrdinal("Fecha")) ? default : reader.GetDateTime(reader.GetOrdinal("Fecha")),
                            Archivo = reader.IsDBNull(reader.GetOrdinal("Archivo")) ? default : reader.GetString(reader.GetOrdinal("Archivo")),
                            Vigente = reader.IsDBNull(reader.GetOrdinal("Vigente")) ? default : reader.GetBoolean(reader.GetOrdinal("Vigente")),
                        };

                        result.Add(entity);
                    }
                    return result;
                }
            }
        }



        public async Task<DocumentoEntity> ObtenerDocumento(int id)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", id);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_Obtener_Documento]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    DocumentoEntity result = null;

                    while (reader.Read())
                    {
                        result = new DocumentoEntity();
                        result.Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo"));
                        result.Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? default : reader.GetString(reader.GetOrdinal("Nombre"));
                        result.Fecha = reader.IsDBNull(reader.GetOrdinal("Fecha")) ? default : reader.GetDateTime(reader.GetOrdinal("Fecha"));
                        result.Archivo = reader.IsDBNull(reader.GetOrdinal("Archivo")) ? default : reader.GetString(reader.GetOrdinal("Archivo"));
                        result.Vigente = reader.IsDBNull(reader.GetOrdinal("Vigente")) ? default : reader.GetBoolean(reader.GetOrdinal("Vigente"));
                    }

                    return result;
                }
            }
        }

        public async Task<int> CrearDocumento(DocumentoEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nombre", variable.Nombre);
                parameters.Add("@fecha", variable.Fecha);
                parameters.Add("@archivo", variable.Archivo);
                parameters.Add("@codigo", null, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                var result = await cnx.ExecuteAsync(
                    "[dbo].[usp_Registrar_Documento]",
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

        public async Task ActualizarDocumento(DocumentoEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", variable.Codigo);
                parameters.Add("@nombre", variable.Nombre);
                parameters.Add("@fecha", variable.Fecha);
                parameters.Add("@archivo", variable.Archivo);

                var result = await cnx.ExecuteAsync(
                   "[dbo].[usp_Actualizar_Documento]",
                   param: parameters,
                   commandType: CommandType.StoredProcedure);

            }
        }
    }
}
