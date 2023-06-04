using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Infrastructure.Persistence;

namespace TicketingSystem.Infrastructure.Repositories
{
    internal class VenueRepository : RepositoryBase<Venue>, IVenueRepository
    {
        public VenueRepository(TicketingDbContext context)
            : base(context) { }
    }
}
