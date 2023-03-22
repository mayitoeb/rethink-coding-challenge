using Dapper;
using webapi.Core.Domain;
using webapi.Core.Interfaces;

namespace webapi.Infrastructure.Data.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DbConnection.DbConnection _dbConnection;
    
        public PatientRepository(DbConnection.DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            const string query = "SELECT Id, FirstName, LastName, Birthday, Gender FROM Patients";

            using var connection = _dbConnection.Open();
            var data = await connection.QueryAsync<Patient>(query);

            return data;
        }

        public async Task AddAsync(IEnumerable<Patient> patients)
        {
            // For demo purposes.
            await ClearDatabase();

            const string query = "INSERT INTO Patients (FirstName, LastName, Birthday, Gender) VALUES (@FirstName, @LastName, @Birthday, @Gender)";

            using var connection = _dbConnection.Open();
            var rowsAffected = await connection.ExecuteAsync(query, patients);
        }

        public async Task UpdateAsync(Patient patient)
        {
            const string query = "UPDATE Patients SET FirstName = @FirstName, LastName = @LastName, Birthday = @Birthday, Gender = @Gender WHERE Id = @Id;";

            using var connection = _dbConnection.Open();
            var rowsAffected = await connection.ExecuteAsync(query, new { patient.Id, patient.FirstName, patient.LastName, patient.Birthday, patient.Gender });
        }

        private async Task ClearDatabase()
        {
            const string query = "DELETE FROM Patients";
            using var connection = _dbConnection.Open();
            var rowsAffected = await connection.ExecuteAsync(query);
        }
    }
}
