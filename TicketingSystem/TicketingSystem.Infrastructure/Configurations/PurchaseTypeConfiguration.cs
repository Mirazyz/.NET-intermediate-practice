using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Infrastructure.Configurations
{
    internal class PurchaseTypeConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable(nameof(Purchase));

            builder.HasKey(p => p.Id);

            builder.HasOne(x => x.Offer)
                .WithOne(p => p.Purchase)
                .HasForeignKey<Purchase>(p => p.Id);

            builder.HasOne(x => x.Customer)
                .WithMany(c => c.Purchases)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
