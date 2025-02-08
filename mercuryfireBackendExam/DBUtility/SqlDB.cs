using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace mercuryfireBackendExam.DBUtility
{
    public class SqlDb
    {
        private readonly string _connectionString;

        public SqlDb(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DBConnectionStr");
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}

