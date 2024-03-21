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
    }
}
