using TicketingSystem.Domain.DTOs.Customer;

namespace TicketingSystem.Domain.Interfaces.Services;

public interface ICustomerService
{
    public Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
    public Task<CustomerDto?> GetCustomerByIdAsync(int id);
    public Task<CustomerDto?> CreateCustomerAsync(CustomerForCreateDto customer);
    public Task UpdateCustomerAsync(CustomerForUpdateDto customer);
    public Task DeleteCustomerAsync(int id);
}
