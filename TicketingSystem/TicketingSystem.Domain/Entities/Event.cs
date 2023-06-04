using TicketingSystem.Domain.Common;

namespace TicketingSystem.Domain.Entities
{
    public class Event : BaseAudibleEntity
    {
        public DateTime EventDate { get; set; }
        public string EventName { get; set; }

        public int VenueId { get; set; }
        public Venue Venue { get; set; }
    }
}
