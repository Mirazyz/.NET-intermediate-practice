using Microsoft.EntityFrameworkCore;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Infrastructure.Persistence
{
    public class TicketingDbContext : DbContext
    {
        public virtual DbSet<Venue> Venue { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Seat> Seat { get; set; }
        public virtual DbSet<Offer> Offer { get; set; }
        public virtual DbSet<Price> Price { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }

        public TicketingDbContext(DbContextOptions<TicketingDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TicketingDbContext).Assembly);
        }
    }
}
