using TicketingSystem.Domain.Common;
using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Domain.Entities
{
    public class Price : BaseAudibleEntity
    {
        public decimal Amount { get; set; }
        public PriceType PriceType { get; set; }

        public int OfferId { get; set; }
        public Offer Offer { get; set; }
    }
}
