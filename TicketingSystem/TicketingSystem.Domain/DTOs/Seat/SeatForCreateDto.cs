using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Domain.DTOs.Seat;

public record SeatForCreateDto(int SeatNumber, int Row, SeatType SeatType, int VenueId);