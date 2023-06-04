using TicketingSystem.Domain.Common;

namespace TicketingSystem.Domain.Entities
{
    public class Venue : BaseAudibleEntity
    {
        public string Name { get; set; }

        public ICollection<Event> VenueEvents { get; set; }
        public ICollection<Seat> Seats { get; set; }

        public Venue()
        {
            VenueEvents = new List<Event>();
            Seats = new HashSet<Seat>();
        }
    }
}
