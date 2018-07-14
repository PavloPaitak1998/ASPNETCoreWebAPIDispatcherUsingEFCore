using FluentValidation;
using Shared.DTO;

namespace Shared.Validators
{
    public class PilotDTOValidator : AbstractValidator<PilotDTO>
    {
        public PilotDTOValidator()
        {
            RuleFor(p => p.FirstName).NotNull().WithMessage("First name can't be null !");
            RuleFor(p => p.LastName).NotNull().WithMessage("Last name  can't be null !");
            RuleFor(p => p.BirthDate).NotEmpty().WithMessage("Birthdate can't be empty !");
            RuleFor(p => p.Experience).NotNull().WithMessage("Experience can't be null !").GreaterThanOrEqualTo(0);

        }
    }
}
