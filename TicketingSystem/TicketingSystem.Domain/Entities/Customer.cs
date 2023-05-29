using TicketingSystem.Domain.Common;

namespace TicketingSystem.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
