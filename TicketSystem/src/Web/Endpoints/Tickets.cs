using MediatR;
using TicketSystem.Application.Common.Models;
using TicketSystem.Application.Tickets.Commands.CreateTicket;
using TicketSystem.Application.Tickets.Commands.HandleTicket;
using TicketSystem.Application.Tickets.Queries.GetTickets;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TicketSystem.Web.Endpoints;

public class Tickets : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetTickets)
            .MapPost(CreateTicket)
            .MapPut(HandleTicket, "Handle/{id}");
    }

    public async Task<PaginatedList<TicketDto>> GetTickets(ISender sender, [AsParameters] GetTicketsQuery query)
    {
        try
        {
            var result = await sender.Send(query);
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }


    public async Task<int> CreateTicket(ISender sender, CreateTicketCommand command)
    {
        try
        {
            var result = await sender.Send(command);
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<IResult> HandleTicket(ISender sender, int id)
    {
        try
        {
            await sender.Send(new HandleTicketCommand { Id = id });
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return Results.Problem(ex.Message);
        }
    }
}
