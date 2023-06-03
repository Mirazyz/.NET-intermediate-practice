using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Infrastructure.Persistence;

namespace TicketingSystem.Infrastructure.Repositories
{
    internal class PriceRepository : RepositoryBase<Price>, IPriceRepository
    {
        public PriceRepository(TicketingDbContext context)
            : base(context) { }
    }
}
