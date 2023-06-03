using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Domain.DTOs.Price;

public record PriceForCreateDto(decimal Amount, PriceType PriceType, int OfferId);