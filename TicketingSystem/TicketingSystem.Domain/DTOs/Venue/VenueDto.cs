using TicketingSystem.Domain.DTOs.Event;
using TicketingSystem.Domain.DTOs.Seat;

namespace TicketingSystem.Domain.DTOs.Venue;

public record VenueDto(int Id, string Name, ICollection<EventDto> VenueEvents, ICollection<SeatDto> Seats);