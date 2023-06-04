namespace TicketingSystem.Domain.DTOs.Event
{
    public record EventForCreateDto(DateTime EventDate, string EventName, int VenueId);
}
