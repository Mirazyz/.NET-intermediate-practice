using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Infrastructure.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserName)
                .HasMaxLength(128)
                .IsRequired();
            builder.Property(x => x.Email)
                .HasMaxLength(128)
                .IsRequired(false);
            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(25)
                .IsRequired(false);
        }
    }
}
