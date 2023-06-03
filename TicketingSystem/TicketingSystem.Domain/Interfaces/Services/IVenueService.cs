using TicketingSystem.Domain.DTOs.Venue;

namespace TicketingSystem.Domain.Interfaces.Services;

public interface IVenueService
{
    public Task<IEnumerable<VenueDto>> GetAllAsync();
    public Task<VenueDto?> GetByIdAsync(int id);
    public Task<VenueDto> CreateAsync(VenueForCreateDto venueToCreate);
    public Task UpdateAsync(VenueForUpdateDto venueToUpdate);
    public Task DeleteAsync(int id);
}
