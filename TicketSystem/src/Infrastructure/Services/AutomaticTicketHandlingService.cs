using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TicketSystem.Application.Common.Interfaces;
using TicketSystem.Domain.Enums;

namespace TicketSystem.Infrastructure.Services;

public class AutomaticTicketHandlingService : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<AutomaticTicketHandlingService> _logger;

    public AutomaticTicketHandlingService(IServiceScopeFactory serviceScopeFactory, ILogger<AutomaticTicketHandlingService> logger)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();

            var now = DateTime.UtcNow;
            var ticketsToHandle = await context.Tickets
                .Where(t => t.Status != TicketStatus.Handled &&
                            EF.Functions.DateDiffMinute(t.Created, now) >= 60)
                .ToListAsync(stoppingToken);

            if (ticketsToHandle.Any())
            {
                foreach (var ticket in ticketsToHandle)
                {
                    ticket.Handle();
                }
                await context.SaveChangesAsync(stoppingToken);
                _logger.LogInformation("Automatically handled {Count} ticket(s).", ticketsToHandle.Count);
            }
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
