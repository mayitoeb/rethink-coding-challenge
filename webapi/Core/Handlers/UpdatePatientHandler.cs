using MediatR;
using webapi.Core.Commands;
using webapi.Core.Domain;
using webapi.Core.Interfaces;

namespace webapi.Core.Handlers
{
    public class UpdatePatientHandler : IRequestHandler<UpdatePatientCommand, Unit>
    {
        private readonly IPatientRepository _repository;

        public UpdatePatientHandler(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = new Patient(request.Id, request.FirstName, request.LastName, request.Birthday, request.Gender);
            await _repository.UpdateAsync(patient);

            return Unit.Value;
        }
    }
}
