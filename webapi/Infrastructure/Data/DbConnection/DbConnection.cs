using System.Data;
using System.Data.SqlClient;

namespace webapi.Infrastructure.Data.DbConnection
{
    public class DbConnection
    {
        private readonly string _connectionString;

        public DbConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection Open() => new SqlConnection(_connectionString);
    }
}
