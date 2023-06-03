using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Infrastructure.Persistence;

namespace TicketingSystem.Infrastructure.Repositories
{
    internal class OfferRepository : RepositoryBase<Customer>, IOfferRepository
    {
        public OfferRepository(TicketingDbContext context)
            : base(context) { }
    }
}
