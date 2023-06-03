using TicketingSystem.Domain.DTOs.Purchase;

namespace TicketingSystem.Domain.Interfaces.Services;

public interface IPurchaseService
{
    public Task<IEnumerable<PurchaseDto>> GetAllAsync();
    public Task<PurchaseDto?> GetByIdAsync(int id);
    public Task<PurchaseDto> CreateAsync(PurchaseForCreateDto purchaseToCreate);
    public Task UpdateAsync(PurchaseForUpdateDto purchaseToUpdate);
    public Task DeleteAsync(int id);
}
