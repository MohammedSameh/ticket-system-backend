using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using TicketSystem.Application.Common.Interfaces;
using TicketSystem.Application.Tickets.Commands.CreateTicket;
using TicketSystem.Domain.Entities;
using Xunit;
using Microsoft.EntityFrameworkCore;

public class CreateTicketCommandTests
{
    private readonly Mock<IApplicationDbContext> _mockDbContext;
    private readonly CreateTicketCommandHandler _handler;
    private readonly Mock<DbSet<Ticket>> _mockTicketDbSet;

    public CreateTicketCommandTests()
    {
        _mockDbContext = new Mock<IApplicationDbContext>();
        _mockTicketDbSet = new Mock<DbSet<Ticket>>();

        _mockDbContext.Setup(db => db.Tickets).Returns(_mockTicketDbSet.Object);
        _mockDbContext.Setup(db => db.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        _handler = new CreateTicketCommandHandler(_mockDbContext.Object);
    }

    [Fact]
    public async Task Handle_ShouldCreateTicket_WhenValidRequest()
    {
        // Arrange
        var command = new CreateTicketCommand
        {
            PhoneNumber = "0123456789",
            Governorate = "Cairo",
            City = "Giza",
            District = "Dokki"
        };

        Ticket savedTicket = null;

        _mockTicketDbSet.Setup(m => m.Add(It.IsAny<Ticket>()))
            .Callback<Ticket>(t =>
            {
                t.Id = 1; 
                savedTicket = t;
            });

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().BeGreaterThan(0); // Ensure a valid ticket ID is returned
        savedTicket.Should().NotBeNull();
        savedTicket.PhoneNumber.Should().Be("0123456789");
        _mockTicketDbSet.Verify(db => db.Add(It.IsAny<Ticket>()), Times.Once);
        _mockDbContext.Verify(db => db.SaveChangesAsync(CancellationToken.None), Times.Once);
    }
}
