using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketSystem.Domain.Entities;

namespace TicketSystem.Infrastructure.Data.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.Property(t => t.PhoneNumber)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(t => t.Governorate)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.City)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.District)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.Status)
            .HasConversion<string>()
            .HasMaxLength(50)
            .IsRequired();
    }
}
