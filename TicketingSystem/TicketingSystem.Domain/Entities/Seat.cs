using TicketingSystem.Domain.Common;
using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Domain.Entities
{
    public class Seat : BaseAudibleEntity
    {
        public int SeatNumber { get; set; }
        public int Row { get; set; }
        public SeatType SeatType { get; set; }

        public int VenueId { get; set; }
        public Venue Venue { get; set; }

        public ICollection<Offer> Offers { get; set; }

        public Seat()
        {
            Offers = new List<Offer>();
        }
    }
}
