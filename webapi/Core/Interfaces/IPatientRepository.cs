using webapi.Core.Domain;

namespace webapi.Core.Interfaces
{
    public interface IPatientRepository
    {
        public Task<IEnumerable<Patient>> GetAllAsync();
        public Task AddAsync(IEnumerable<Patient> patients);
        public Task UpdateAsync(Patient patient);
    }
}
