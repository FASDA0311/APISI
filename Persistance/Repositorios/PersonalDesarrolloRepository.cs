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
    public class PersonalDesarrolloRepository : IPersonalDesarrolloRepository
    {
        private readonly IDataBase _dataBase;

        public PersonalDesarrolloRepository(IServiceProvider serviceProvider)
        {
            var services = serviceProvider.GetServices<IDataBase>();
            _dataBase = services.First(s => s.GetType() == typeof(SIDataBase));
        }

        public async Task<IEnumerable<PersonalDesarrolloEntity>> ListarPersonalDesarrollo()
        {
            using (var cnx = _dataBase.GetConnection())
            {
                using (var reader = await cnx.ExecuteReaderAsync(
                     "[dbo].[usp_Listar_PersonalDesarrollo]",
                    commandType: CommandType.StoredProcedure))
                {
                    var result = new List<PersonalDesarrolloEntity>();

                    while (reader.Read())
                    {
                        var entity = new PersonalDesarrolloEntity()
                        {
                            Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo")),
                            CodigoPersonalSoporte = reader.IsDBNull(reader.GetOrdinal("CodigoPersonalSoporte")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoPersonalSoporte")),
                            CodigoDesarrollo = reader.IsDBNull(reader.GetOrdinal("CodigoDesarrollo")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoDesarrollo"))
                        };

                        result.Add(entity);
                    }
                    return result;
                }
            }
        }



        public async Task<PersonalDesarrolloEntity> ObtenerPersonalDesarrollo(int id)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", id);

                using (var reader = await cnx.ExecuteReaderAsync(
                    "[dbo].[usp_Obtener_PersonalDesarrollo]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure))
                {
                    PersonalDesarrolloEntity result = null;

                    while (reader.Read())
                    {
                        result = new PersonalDesarrolloEntity();
                        result.Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? default : reader.GetInt32(reader.GetOrdinal("Codigo"));
                        result.CodigoPersonalSoporte = reader.IsDBNull(reader.GetOrdinal("CodigoPersonalSoporte")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoPersonalSoporte"));
                        result.CodigoDesarrollo = reader.IsDBNull(reader.GetOrdinal("CodigoDesarrollo")) ? default : reader.GetInt32(reader.GetOrdinal("CodigoDesarrollo"));
                    }

                    return result;
                }
            }
        }

        public async Task<int> CrearPersonalDesarrollo(PersonalDesarrolloEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigopersonalsoporte", variable.CodigoPersonalSoporte);
                parameters.Add("@codigodesarrollo", variable.CodigoDesarrollo);
                parameters.Add("@codigo", null, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                var result = await cnx.ExecuteAsync(
                    "[dbo].[usp_Registrar_PersonalDesarrollo]",
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

        public async Task ActualizarPersonalDesarrollo(PersonalDesarrolloEntity variable)
        {
            using (var cnx = _dataBase.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@codigo", variable.Codigo);
                parameters.Add("@codigopersonalsoporte", variable.CodigoPersonalSoporte);
                parameters.Add("@codigodesarrollo", variable.CodigoDesarrollo);

                var result = await cnx.ExecuteAsync(
                   "[dbo].[usp_Actualizar_PersonalDesarrollo]",
                   param: parameters,
                   commandType: CommandType.StoredProcedure);

            }
        }
    }
}

