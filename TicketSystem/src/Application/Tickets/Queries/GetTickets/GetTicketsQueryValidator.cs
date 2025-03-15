using FluentValidation;
using TicketSystem.Application.Tickets.Queries.GetTickets;

namespace TicketSystem.Application.Tickets.Queries.GetTickets;

public sealed class GetTicketsQueryValidator : AbstractValidator<GetTicketsQuery>
{
    public GetTicketsQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0).WithMessage("Page number must be greater than zero.");
        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 1000000).WithMessage("Page size must be between 1 and 1000000.");
    }
}
