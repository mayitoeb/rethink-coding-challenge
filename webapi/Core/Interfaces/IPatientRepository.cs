using webapi.Core.Domain;

namespace webapi.Core.Interfaces
{
    public interface IPatientRepository
    {
        public Task AddAsync(IEnumerable<Patient> patients);
    }
}
