namespace TicketingSystem.Domain.DTOs.Customer;

public record CustomerForUpdateDto(int Id, string UserName, string Email, string PhoneNumber);