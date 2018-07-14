using FluentValidation;
using Shared.DTO;

namespace Shared.Validators
{
    public class DepartureDTOValidator : AbstractValidator<DepartureDTO>
    {
        public DepartureDTOValidator()
        {
            RuleFor(d => d.Time).NotEmpty().WithMessage("Time can't be empty !");
            RuleFor(d => d.CrewId).NotEmpty().WithMessage("Crew Id  can't be empty !");
            RuleFor(d => d.PlaneId).NotEmpty().WithMessage("Plane Id can't be empty !");
            RuleFor(d => d.FlightNumber).NotEmpty().WithMessage("Flight Number can't be empty !");
            RuleFor(d => d.FlightId).NotEmpty().WithMessage("Flight Id can't be empty !");

        }
    }
}
