using FluentValidation;
using Shared.DTO;

namespace Shared.Validators
{
    public class PlaneDTOValidator : AbstractValidator<PlaneDTO>
    {
        public PlaneDTOValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("Name can't be null !");
            RuleFor(p => p.PlaneTypeId).NotEmpty().WithMessage("Type Id  can't be empty !").GreaterThan(0);
            RuleFor(p => p.ReleaseDate).NotEmpty().WithMessage("Release Date can't be empty !");
            RuleFor(p => p.Lifetime).NotEmpty().WithMessage("Lifetime can't be empty !");

        }
    }
}
