using TicketingSystem.Domain.DTOs.Offer;

namespace TicketingSystem.Domain.Interfaces.Services;

public interface IOfferService
{
    public Task<IEnumerable<OfferDto>> GetAllAsync();
    public Task<OfferDto?> GetByIdAsync(int id);
    public Task<OfferDto?> CreatAsync(OfferForCreateDto offerToCreate);
    public Task UpdateAsync(OfferForUpdateDto offerToUpdate);
    public Task DeleteAsync(int id);
}
