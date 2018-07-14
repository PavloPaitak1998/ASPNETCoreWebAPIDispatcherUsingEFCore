using FluentValidation;
using Shared.DTO;

namespace Shared.Validators
{
    public class TicketDTOValidator : AbstractValidator<TicketDTO>
    {
        public TicketDTOValidator()
        {
            RuleFor(t => t.Price).NotEmpty().WithMessage("Price can't be empty !").GreaterThan(0);
            RuleFor(t => t.FlightNumber).NotEmpty().WithMessage("Flight Number can't be empty !").GreaterThan(0);
            RuleFor(t => t.FlightId).NotEmpty().WithMessage("Flight Id can't be empty !").GreaterThan(0);

        }
    }
}
