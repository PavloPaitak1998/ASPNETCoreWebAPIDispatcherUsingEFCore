using FluentValidation;
using Shared.DTO;

namespace Shared.Validators
{
    public class PlaneTypeDTOValidator : AbstractValidator<PlaneTypeDTO>
    {
        public PlaneTypeDTOValidator()
        {
            RuleFor(pt => pt.Model).NotNull().WithMessage("Model can't be null !");
            RuleFor(pt => pt.Seats).NotEmpty().WithMessage("Seats  can't be empty !").GreaterThan(0);
            RuleFor(pt => pt.Carrying).NotEmpty().WithMessage("Carryingcan't be empty !").GreaterThan(0);

        }
    }
}
