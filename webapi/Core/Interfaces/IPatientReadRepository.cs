using webapi.Core.Domain;

namespace webapi.Core.Interfaces
{
    public interface IPatientReadRepository
    {
        public Task<IEnumerable<Patient>> GetAllAsync();
    }
}
