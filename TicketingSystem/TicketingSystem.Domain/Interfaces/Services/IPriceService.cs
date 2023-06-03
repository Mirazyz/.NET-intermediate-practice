using TicketingSystem.Domain.DTOs.Price;

namespace TicketingSystem.Domain.Interfaces.Services
{
    public interface IPriceService
    {
        public Task<IEnumerable<PriceDto>> GetAllAsync();
        public Task<PriceDto?> GetByIdAsync(int id);
        public Task<PriceDto> CreateAsync(PriceForCreateDto priceToCreate);
        public Task UpdateAsync(PriceForUpdateDto priceToUpdate);
        public Task DeleteAsync(int id);
    }
}
