using TicketingSystem.Domain.DTOs.Seat;

namespace TicketingSystem.Domain.Interfaces.Services;

public interface ISeatService
{
    public Task<IEnumerable<SeatDto>> GetAllAsync();
    public Task<SeatDto?> GetByIdAsync(int id);
    public Task<SeatDto> CreateAsync(SeatForCreateDto seatToCreate);
    public Task UpdateAsync(SeatForUpdateDto seatToUpdate);
    public Task DeleteAsync(int id);
}
