using TicketSystem.Domain.Entities;

namespace TicketSystem.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    public DbSet<Ticket> Tickets { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
