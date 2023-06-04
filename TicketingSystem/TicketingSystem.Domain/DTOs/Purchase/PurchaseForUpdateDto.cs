namespace TicketingSystem.Domain.DTOs.Purchase;

public record PurchaseForUpdateDto(int Id, DateTime PurchaseDate, int CustomerId);