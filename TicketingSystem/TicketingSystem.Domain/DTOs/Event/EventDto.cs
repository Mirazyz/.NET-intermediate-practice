using TicketingSystem.Domain.DTOs.Venue;

namespace TicketingSystem.Domain.DTOs.Event;

public record EventDto(int Id, DateTime EventDate, string EventName, int VenueId, VenueDto Venue);