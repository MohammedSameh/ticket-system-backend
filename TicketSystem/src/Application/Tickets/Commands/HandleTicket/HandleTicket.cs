using MediatR;
using TicketSystem.Application.Common.Interfaces;
using TicketSystem.Domain.Entities;
using TicketSystem.Domain.Enums;

namespace TicketSystem.Application.Tickets.Commands.HandleTicket;

public sealed record HandleTicketCommand : IRequest<Unit>
{
    public int Id { get; init; }
}

public sealed class HandleTicketCommandHandler : IRequestHandler<HandleTicketCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public HandleTicketCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(HandleTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _context.Tickets.FindAsync(new object[] { request.Id }, cancellationToken);
        if (ticket is not null && ticket.Status != TicketStatus.Handled)
        {
            ticket.Handle();
            await _context.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;
    }
}
