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

        /// <summary>
        /// Bussiness logic goes here
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Patient>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return data;
        }
    }
}
