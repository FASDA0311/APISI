using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.DataBase
{
    public class SIDataBase : IDataBase
    {
        private SqlConnection _connection;
        private readonly string _connectionString;

        public SIDataBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            if (_connection == null || string.IsNullOrWhiteSpace(_connection.ConnectionString))
            {
                _connection = new SqlConnection(_connectionString);
            }
            return _connection;
        }
    }
}
