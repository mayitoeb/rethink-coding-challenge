using MediatR;

namespace webapi.Core.Commands
{
    public class UpdatePatientCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public char Gender { get; set; }
    }
}
