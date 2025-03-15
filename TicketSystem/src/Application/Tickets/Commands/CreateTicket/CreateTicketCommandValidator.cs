using FluentValidation;
using TicketSystem.Application.Tickets.Commands.CreateTicket;

namespace TicketSystem.Application.Tickets.Commands.CreateTicket;

public sealed class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
{
    public CreateTicketCommandValidator()
    {
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .MaximumLength(20).WithMessage("Phone number must not exceed 20 characters.");
        RuleFor(x => x.Governorate).NotEmpty().WithMessage("Governorate is required.");
        RuleFor(x => x.City).NotEmpty().WithMessage("City is required.");
        RuleFor(x => x.District).NotEmpty().WithMessage("District is required.");
    }
}
