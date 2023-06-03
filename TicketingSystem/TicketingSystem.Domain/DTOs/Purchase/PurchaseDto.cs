using TicketingSystem.Domain.DTOs.Customer;
using TicketingSystem.Domain.DTOs.Offer;

namespace TicketingSystem.Domain.DTOs.Purchase;

public record PurchaseDto(int Id, DateTime PurchaseDate, OfferDto Offer, int CustomerId, CustomerDto Customer);