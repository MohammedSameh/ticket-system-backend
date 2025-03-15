using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Application.Common.Interfaces;
using TicketSystem.Application.Common.Mappings;
using TicketSystem.Application.Common.Models;

namespace TicketSystem.Application.Tickets.Queries.GetTickets;

public record GetTicketsQuery : IRequest<PaginatedList<TicketDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTicketsQueryHandler : IRequestHandler<GetTicketsQuery, PaginatedList<TicketDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTicketsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TicketDto>> Handle(GetTicketsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Tickets
            .OrderByDescending(t => t.Created)
            .ProjectTo<TicketDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
