using MediatR;
using TicketSystem.Application.Common.Interfaces;
using TicketSystem.Domain.Entities;

namespace TicketSystem.Application.Tickets.Commands.CreateTicket;

public sealed record CreateTicketCommand : IRequest<int>
{
    public string? PhoneNumber { get; init; }
    public string? Governorate { get; init; }
    public string? City { get; init; }
    public string? District { get; init; }
}

public sealed class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTicketCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<int> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = new Ticket
        {
            PhoneNumber = request.PhoneNumber,
            Governorate = request.Governorate,
            City = request.City,
            District = request.District
        };

        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync(cancellationToken);
        return ticket.Id;
    }
}
