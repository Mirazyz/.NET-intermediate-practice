using TicketingSystem.Domain.DTOs.Offer;
using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Domain.DTOs.Seat;

public record SeatDto(int Id, int SeatNumber, int Row, SeatType SeatType,
    int VenueId, Venue Venue, ICollection<OfferDto> Offers);