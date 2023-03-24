using MediatR;
using webapi.Core.Domain;

namespace webapi.Core.Queries
{
    public class GetAllPatientsQuery : IRequest<IEnumerable<Patient>>
    {
    }
}
