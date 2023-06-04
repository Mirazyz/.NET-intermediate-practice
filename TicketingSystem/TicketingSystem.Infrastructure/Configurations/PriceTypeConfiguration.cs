using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Infrastructure.Configurations
{
    public class PriceTypeConfiguration : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.ToTable(nameof(Price));

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Offer)
                .WithMany(o => o.Prices)
                .HasForeignKey(x => x.OfferId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
