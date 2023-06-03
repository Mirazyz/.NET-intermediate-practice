using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Infrastructure.Persistence;

namespace TicketingSystem.Infrastructure.Repositories
{
    internal class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(TicketingDbContext context)
            : base(context) { }
    }
}
