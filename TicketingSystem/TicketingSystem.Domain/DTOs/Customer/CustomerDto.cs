using TicketingSystem.Domain.DTOs.Purchase;

namespace TicketingSystem.Domain.DTOs.Customer;

public record CustomerDto(int Id, string UserName, string Email, string PhoneNumber,
    ICollection<PurchaseDto> Purchases);