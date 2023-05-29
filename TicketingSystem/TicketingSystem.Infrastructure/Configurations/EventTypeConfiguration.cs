using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Infrastructure.Configurations
{
    public class EventTypeConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable(nameof(Event));

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Venue)
                .WithMany(v => v.VenueEvents)
                .HasForeignKey(x => x.VenueId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.EventName)
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}
