using TicketingSystem.Domain.DTOs.Venue;

namespace TicketingSystem.Domain.Interfaces.Services;

public interface IVenueService
{
    public Task<IEnumerable<VenueDto>> GetAllVenuesAsync();
    public Task<VenueDto?> GetVenueByIdAsync(int id);
    public Task<VenueDto> CreateVenueAsync(VenueForCreateDto venueToCreate);
    public Task UpdateVenueAsync(VenueForUpdateDto venueToUpdate);
    public Task DeleteVenueAsync(int id);
}
