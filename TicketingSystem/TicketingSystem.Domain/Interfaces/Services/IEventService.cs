using TicketingSystem.Domain.DTOs.Event;

namespace TicketingSystem.Domain.Interfaces.Services;

public interface IEventService
{
    public Task<IEnumerable<EventDto>> GetAllAsync();
    public Task<EventDto?> GetByIdAsync(int id);
    public Task<EventDto> CreateAsync(EventForCreateDto eventToCreate);
    public Task UpdateAsync(EventForUpdateDto eventToUpdate);
    public Task<EventDto> DeleteAsync(int id);
}
