using TicketingSystem.Domain.Common;

namespace TicketingSystem.Domain.Entities
{
    public class Purchase : BaseAudibleEntity
    {
        public DateTime PurchaseDate { get; set; }

        public int OfferId { get; set; }
        public Offer Offer { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
