using TicketingSystem.Domain.Common;
using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Domain.Entities
{
    public class Offer : BaseAudibleEntity
    {
        public OfferStatus Status { get; set; }

        public ICollection<Price> Prices { get; set; }

        public Offer()
        {
            Prices = new HashSet<Price>();
        }
    }
}
