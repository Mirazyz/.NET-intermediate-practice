using TicketingSystem.Domain.DTOs.Offer;
using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Domain.DTOs.Price;

public record PriceDto(int Id, decimal Amount, PriceType PriceType, int OfferId, OfferDto Offer);