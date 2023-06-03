using TicketingSystem.Domain.DTOs.Offer;
using TicketingSystem.Domain.DTOs.Venue;
using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Domain.DTOs.Seat;

public record SeatDto(int Id, int SeatNumber, int Row, SeatType SeatType,
    int VenueId, VenueDto Venue, ICollection<OfferDto> Offers);