using FluentValidation;
using Shared.DTO;

namespace Shared.Validators
{
    public class CrewDTOValidator : AbstractValidator<CrewDTO>
    {
        public CrewDTOValidator()
        {
            RuleFor(c => c.PilotId).NotEmpty().WithMessage("Pilot id can't be empty !").GreaterThan(0);
        }

    }
}
