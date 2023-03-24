using FluentValidation;
using MediatR;

namespace webapi.Core.Commands
{
    public class UpdatePatientCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public string Gender { get; set; } = string.Empty;
    }

    public class UpdatePatientCommandValidator : AbstractValidator<UpdatePatientCommand>
    {
        public UpdatePatientCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();

            RuleFor(x => x.LastName).NotEmpty();

            RuleFor(x => x.Birthday).LessThan(DateTime.Now);

            RuleFor(x => x.Gender).NotEmpty();
            RuleFor(x => x.Gender).MaximumLength(1);
        }
    }
}
