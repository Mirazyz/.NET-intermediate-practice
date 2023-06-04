using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Infrastructure.Persistence;

namespace TicketingSystem.Infrastructure.Repositories
{
    internal class SeatRepository : RepositoryBase<Seat>, ISeatRepository
    {
        public SeatRepository(TicketingDbContext context)
            : base(context) { }
    }
}
