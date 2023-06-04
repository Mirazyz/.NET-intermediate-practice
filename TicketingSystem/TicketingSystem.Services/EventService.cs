using AutoMapper;
using Microsoft.Extensions.Logging;
using TicketingSystem.Domain.DTOs.Event;
using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Exceptions;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Domain.Interfaces.Services;

namespace TicketingSystem.Services
{
    public class EventService : IEventService
    {
        private readonly ICommonRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<IEventService> _logger;

        public EventService(ICommonRepository repository, IMapper mapper, ILogger<IEventService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<EventDto>> GetAllEventsAsync()
        {
            var events = await _repository.Event.FindAllAsync();

            return _mapper.Map<IEnumerable<EventDto>>(events);
        }

        public async Task<EventDto?> GetEventByIdAsync(int id)
        {
            var eventEntity = await _repository.Event.FindByIdAsync(id);

            if (eventEntity is null)
            {
                throw new EntityDoesNotExistException($"Event with id: {id} does not exist.");
            }

            return _mapper.Map<EventDto>(eventEntity);
        }

        public async Task<EventDto?> CreateEventAsync(EventForCreateDto eventToCreate)
        {
            ArgumentNullException.ThrowIfNull(eventToCreate);

            try
            {
                var eventEntity = _mapper.Map<Event>(eventToCreate);

                var createdEvent = _repository.Event.Create(eventEntity);
                await _repository.SaveChangesAsync();

                return _mapper.Map<EventDto>(createdEvent);
            }
            catch (Exception ex)
            {
                _logger.LogError("There was an error creating new event.", ex);
                throw;
            }
        }

        public async Task UpdateEventAsync(EventForUpdateDto eventToUpdate)
        {
            ArgumentNullException.ThrowIfNull(eventToUpdate);

            try
            {
                var eventEntity = _mapper.Map<Event>(eventToUpdate);

                _repository.Event.Update(eventEntity);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while updating Event with id: {eventToUpdate.Id}", ex);
                throw;
            }
        }

        public async Task DeleteEventAsync(int id)
        {
            var eventEntity = await _repository.Event.FindByIdAsync(id) ??
                throw new ArgumentException($"Event with id: {id} does not exist.", nameof(id));

            _repository.Event.Delete(eventEntity);
            await _repository.SaveChangesAsync();
        }
    }
}
