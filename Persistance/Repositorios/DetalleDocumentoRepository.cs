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
    }
}
