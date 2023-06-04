using TicketingSystem.Domain.DTOs.Seat;

namespace TicketingSystem.Domain.Interfaces.Services;

public interface ISeatService
{
    public Task<IEnumerable<SeatDto>> GetAllSeatsAsync();
    public Task<SeatDto?> GetSeatByIdAsync(int id);
    public Task<SeatDto> CreateSeatAsync(SeatForCreateDto seatToCreate);
    public Task UpdateSeatAsync(SeatForUpdateDto seatToUpdate);
    public Task DeleteSeatAsync(int id);
}
