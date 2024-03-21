using Application.Common.Interfaces.Repositorios;
using Application.Common.Interfaces;
using Domain.Entidades;
using Microsoft.Extensions.DependencyInjection;
using Persistance.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

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
    }
}
