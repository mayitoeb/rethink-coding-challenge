using MediatR;
using webapi.Core.Domain;
using webapi.Core.Interfaces;
using webapi.Core.Queries;

namespace webapi.Core.Handlers
{
    public class GetAllPatientsHandler : IRequestHandler<GetAllPatientsQuery, IEnumerable<Patient>>
    {
        private readonly IPatientRepository _repository;

        public GetAllPatientsHandler(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Patient>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return data;
        }
    }
}
