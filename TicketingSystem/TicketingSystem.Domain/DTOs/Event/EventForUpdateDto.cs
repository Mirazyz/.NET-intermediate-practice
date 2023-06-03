namespace TicketingSystem.Domain.DTOs.Event;

public record EventForUpdateDto(int Id, DateTime EventDate, string EventName, int VenueId);