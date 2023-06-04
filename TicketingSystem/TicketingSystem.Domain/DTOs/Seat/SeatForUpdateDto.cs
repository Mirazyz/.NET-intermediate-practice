using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Domain.DTOs.Seat;

public record SeatForUpdateDto(int Id, int SeatNumber, int Row, SeatType SeatType, int VenueId);