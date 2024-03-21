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
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDataBase _dataBase;

        public UsuarioRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SIDataBase));
        }

        public async Task<IEnumerable<UsuarioEntity>> ListarUsuario()
        {
            using (var cnx = _dataBase.GetConnection())
            {
                using (var reader = await cnx.ExecuteReaderAsync(
                     "[dbo].[usp_Listar_Usuario]",
                    commandType: CommandType.StoredProcedure))
                {
                    var result = new List<UsuarioEntity>();

                    while (reader.Read())
                    {
                        var entity = new UsuarioEntity()
                        {
                            Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo")),
                            Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? default : reader.GetString(reader.GetOrdinal("Nombre")),
                            Contraseña = reader.IsDBNull(reader.GetOrdinal("Contraseña")) ? default : reader.GetString(reader.GetOrdinal("Contraseña")),
                            TipoUsuario = reader.IsDBNull(reader.GetOrdinal("TipoUsuario")) ? default : reader.GetChar(reader.GetOrdinal("TipoUsuario")),
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
