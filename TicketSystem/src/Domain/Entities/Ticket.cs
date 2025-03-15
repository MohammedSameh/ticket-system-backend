using TicketSystem.Domain.Common;
using TicketSystem.Domain.Enums;

namespace TicketSystem.Domain.Entities;

public class Ticket : BaseAuditableEntity
{
    public string? PhoneNumber { get; set; }
    public string? Governorate { get; set; }
    public string? City { get; set; }
    public string? District { get; set; }
    public TicketStatus Status { get; set; }
    
    public void Handle() => Status = TicketStatus.Handled;
}
