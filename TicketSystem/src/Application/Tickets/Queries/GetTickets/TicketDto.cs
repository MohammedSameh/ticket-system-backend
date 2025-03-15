using TicketSystem.Domain.Entities;
using TicketSystem.Domain.Enums;

namespace TicketSystem.Application.Tickets.Queries.GetTickets;

public sealed class TicketDto
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Governorate { get; set; }
    public string? City { get; set; }
    public string? District { get; set; }
    public TicketStatus Status { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Ticket, TicketDto>()
                .ForMember(dto => dto.Created, opt => opt.MapFrom(src => src.Created.UtcDateTime)); 
        }
    }
}
