using TicketingSystem.Domain.DTOs.Price;
using TicketingSystem.Domain.DTOs.Purchase;
using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Domain.DTOs.Offer;

public record OfferDto(OfferStatus OfferStatus, int SeatId, PurchaseDto? Purchase, ICollection<PriceDto> Prices);