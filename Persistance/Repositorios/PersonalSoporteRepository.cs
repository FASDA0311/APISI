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
    public class PersonalSoporteRepository : IPersonalSoporteRepository
    {
        private readonly IDataBase _dataBase;

        public PersonalSoporteRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SIDataBase));
        }

        public async Task<IEnumerable<PersonalSoporteEntity>> ListarPersonalSoporte()
        {
            using (var cnx = _dataBase.GetConnection())
            {
                using (var reader = await cnx.ExecuteReaderAsync(
                     "[dbo].[usp_Listar_PersonalSoporte]",
                    commandType: CommandType.StoredProcedure))
                {
                    var result = new List<PersonalSoporteEntity>();

                    while (reader.Read())
                    {
                        var entity = new PersonalSoporteEntity()
                        {
                            Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo")),
                            Nombres = reader.IsDBNull(reader.GetOrdinal("Nombres")) ? default : reader.GetString(reader.GetOrdinal("Nombres")),
                            Apellidos = reader.IsDBNull(reader.GetOrdinal("Apellidos")) ? default : reader.GetString(reader.GetOrdinal("Apellidos")),
                            Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? default : reader.GetString(reader.GetOrdinal("Telefono")),
                            Correo = reader.IsDBNull(reader.GetOrdinal("Correo")) ? default : reader.GetString(reader.GetOrdinal("Correo")),
                            DNI = reader.IsDBNull(reader.GetOrdinal("DNI")) ? default : reader.GetString(reader.GetOrdinal("DNI")),
                            Estado = reader.IsDBNull(reader.GetOrdinal("Vigente")) ? default : reader.GetBoolean(reader.GetOrdinal("Vigente")),
                            CodigoUsuario = reader.IsDBNull(reader.GetOrdinal("CodigoUsuario")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoUsuario")),
                        };

                        result.Add(entity);
                    }
                    return result;
                }
            }
        }



        public async Task<PersonalSoporteEntity> ObtenerPersonalSoporte(int id)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", id);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_Obtener_PersonalSoporte]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    PersonalSoporteEntity result = null;

                    while (reader.Read())
                    {
                        result = new PersonalSoporteEntity();
                        result.Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo"));
                        result.Nombres = reader.IsDBNull(reader.GetOrdinal("Nombres")) ? default : reader.GetString(reader.GetOrdinal("Nombres"));
                        result.Apellidos = reader.IsDBNull(reader.GetOrdinal("Apellidos")) ? default : reader.GetString(reader.GetOrdinal("Apellidos"));
                        result.Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? default : reader.GetString(reader.GetOrdinal("Telefono"));
                        result.Correo = reader.IsDBNull(reader.GetOrdinal("Correo")) ? default : reader.GetString(reader.GetOrdinal("Correo"));
                        result.DNI = reader.IsDBNull(reader.GetOrdinal("DNI")) ? default : reader.GetString(reader.GetOrdinal("DNI"));
                        result.Estado = reader.IsDBNull(reader.GetOrdinal("Vigente")) ? default : reader.GetBoolean(reader.GetOrdinal("Vigente"));
                        result.CodigoUsuario = reader.IsDBNull(reader.GetOrdinal("CodigoUsuario")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoUsuario"));
                    }

                    return result;
                }
            }
        }

        public async Task<int> CrearPersonalSoporte(PersonalSoporteEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@nombres", variable.Nombres);
                parameters.Add("@apellidos", variable.Apellidos);
                parameters.Add("@telefono", variable.Telefono);
                parameters.Add("@correo", variable.Correo);
                parameters.Add("@dni", variable.DNI);
                parameters.Add("@codigo", null, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                var result = await cnx.ExecuteAsync(
                    "[dbo].[usp_Registrar_PersonalSoporte]",
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

        public async Task ActualizarPersonalSoporte(PersonalSoporteEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", variable.Codigo);
                parameters.Add("@nombres", variable.Nombres);
                parameters.Add("@apellidos", variable.Apellidos);
                parameters.Add("@telefono", variable.Telefono);
                parameters.Add("@correo", variable.Correo);
                parameters.Add("@dni", variable.DNI);
                parameters.Add("@vigente", variable.Estado);
                parameters.Add("@codigousu", variable.CodigoUsuario);

                var result = await cnx.ExecuteAsync(
                   "[dbo].[usp_Actualizar_PersonalSoporte]",
                   param: parameters,
                   commandType: CommandType.StoredProcedure);

            }
        }
    }
}
