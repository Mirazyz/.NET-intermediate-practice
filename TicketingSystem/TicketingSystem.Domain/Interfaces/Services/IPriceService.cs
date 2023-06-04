using TicketingSystem.Domain.DTOs.Price;

namespace TicketingSystem.Domain.Interfaces.Services
{
    public interface IPriceService
    {
        public Task<IEnumerable<PriceDto>> GetAllPricesAsync();
        public Task<PriceDto?> GetPriceByIdAsync(int id);
        public Task<PriceDto> CreatePriceAsync(PriceForCreateDto priceToCreate);
        public Task UpdatePriceAsync(PriceForUpdateDto priceToUpdate);
        public Task DeletePriceAsync(int id);
    }
}
