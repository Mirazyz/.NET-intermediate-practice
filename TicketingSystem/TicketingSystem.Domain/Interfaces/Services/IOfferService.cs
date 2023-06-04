using TicketingSystem.Domain.DTOs.Offer;

namespace TicketingSystem.Domain.Interfaces.Services;

public interface IOfferService
{
    public Task<IEnumerable<OfferDto>> GetAllOffersAsync();
    public Task<OfferDto?> GetOfferByIdAsync(int id);
    public Task<OfferDto?> CreateOfferAsync(OfferForCreateDto offerToCreate);
    public Task UpdateOfferAsync(OfferForUpdateDto offerToUpdate);
    public Task DeleteOfferAsync(int id);
}
