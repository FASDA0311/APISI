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
                            CodigoPersonalSoporte = reader.IsDBNull(reader.GetOrdinal("CodigoPersonalSoporte ")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoPersonalSoporte")),
                        };

                        result.Add(entity);
                    }
                    return result;
                }
            }
        }



        public async Task<UsuarioEntity> ObtenerUsuario(int id)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", id);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_Obtener_Usuario]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    UsuarioEntity result = null;

                    while (reader.Read())
                    {
                        result = new UsuarioEntity();
                        result.Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo"));
                        result.Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? default : reader.GetString(reader.GetOrdinal("Nombre"));
                        result.Contraseña = reader.IsDBNull(reader.GetOrdinal("Contraseña")) ? default : reader.GetString(reader.GetOrdinal("Contraseña"));
                        result.TipoUsuario = reader.IsDBNull(reader.GetOrdinal("TipoUsuario")) ? default : reader.GetChar(reader.GetOrdinal("TipoUsuario"));
                        result.Vigente = reader.IsDBNull(reader.GetOrdinal("Vigente")) ? default : reader.GetBoolean(reader.GetOrdinal("Vigente"));
                        result.CodigoPersonalSoporte = reader.IsDBNull(reader.GetOrdinal("CodigoPersonalSoporte ")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoPersonalSoporte"));
                    }

                    return result;
                }
            }
        }

        public async Task<int> CrearUsuario(UsuarioEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nombre", variable.Nombre);
                parameters.Add("@contraseña", variable.Contraseña);
                parameters.Add("@tipousuario", variable.TipoUsuario);
                parameters.Add("@codigo", null, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                var result = await cnx.ExecuteAsync(
                    "[dbo].[usp_Registrar_Usuario]",
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

        public async Task ActualizarUsuario(UsuarioEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", variable.Codigo);
                parameters.Add("@nombre", variable.Nombre);
                parameters.Add("@contraseña", variable.Contraseña);
                parameters.Add("@tipousuario", variable.TipoUsuario);
                parameters.Add("@vigente", variable.Vigente);
                parameters.Add("@codigopersonalsoporte", variable.CodigoPersonalSoporte);

                var result = await cnx.ExecuteAsync(
                   "[dbo].[usp_Actualizar_Usuario]",
                   param: parameters,
                   commandType: CommandType.StoredProcedure);

            }
        }
    }
}
