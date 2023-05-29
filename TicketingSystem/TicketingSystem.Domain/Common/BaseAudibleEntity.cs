namespace TicketingSystem.Domain.Common
{
    public class BaseAudibleEntity : BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public string? LastUpdatedBy { get; set; }
    }
}
