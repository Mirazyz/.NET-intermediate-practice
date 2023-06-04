using TicketingSystem.Domain.DTOs.Purchase;

namespace TicketingSystem.Domain.Interfaces.Services;

public interface IPurchaseService
{
    public Task<IEnumerable<PurchaseDto>> GetAllPurchasesAsync();
    public Task<PurchaseDto?> GetPurchaseByIdAsync(int id);
    public Task<PurchaseDto> CreatePurchaseAsync(PurchaseForCreateDto purchaseToCreate);
    public Task UpdatePurchaseAsync(PurchaseForUpdateDto purchaseToUpdate);
    public Task DeletePurchaseAsync(int id);
}
