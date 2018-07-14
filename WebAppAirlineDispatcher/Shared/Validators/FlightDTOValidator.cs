using FluentValidation;
using Shared.DTO;

namespace Shared.Validators
{
    public class FlightDTOValidator : AbstractValidator<FlightDTO>
    {
        public FlightDTOValidator()
        {
            RuleFor(f => f.Number).NotEmpty().WithMessage("Flight number can't be empty !").GreaterThan(0);
            RuleFor(f => f.PointOfDeparture).NotNull().WithMessage("Point of departure can't be null !");
            RuleFor(f => f.DepartureTime).NotEmpty().WithMessage("Departure time  can't be empty !");
            RuleFor(f => f.Destination).NotNull().WithMessage("Destination can't be empty !");
            RuleFor(f => f.DestinationTime).NotEmpty().WithMessage("Destination time can't be null !");

        }
    }
}
