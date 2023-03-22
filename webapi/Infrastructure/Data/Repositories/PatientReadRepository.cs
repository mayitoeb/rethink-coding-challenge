using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using webapi.Core.Domain;
using webapi.Core.Interfaces;

namespace webapi.Infrastructure.Data.Repositories
{
    public class PatientReadRepository : IPatientReadRepository
    {
        private readonly DbConnection.DbConnection _dbConnection;

        public PatientReadRepository(DbConnection.DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            const string query = "SELECT FirstName, LastName, Birthday, Gender FROM Patients";

            using var connection = _dbConnection.Open();
            var data = await connection.QueryAsync<Patient>(query);

            return data;
        }
    }
}
