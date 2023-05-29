using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Infrastructure.Configurations
{
    public class OfferTypeConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.ToTable(nameof(Offer));

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Seat)
                .WithMany(s => s.Offers)
                .HasForeignKey(x => x.SeatId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
