using TicketingSystem.Domain.Enums;

namespace TicketingSystem.Domain.DTOs.Price;

public record PriceForUpdateDto(int Id, decimal Amount, PriceType PriceType, int OfferId);
