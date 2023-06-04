using AutoMapper;
using Microsoft.Extensions.Logging;
using TicketingSystem.Domain.DTOs.Venue;
using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Domain.Interfaces.Services;

namespace TicketingSystem.Services
{
    public class VenueService : IVenueService
    {
        private readonly ICommonRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<ISeatService> _logger;

        public VenueService(ICommonRepository repository, IMapper mapper, ILogger<ISeatService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<VenueDto>> GetAllVenuesAsync()
        {
            var venues = await _repository.Venue.FindAllAsync();

            return _mapper.Map<IEnumerable<VenueDto>>(venues) ?? Enumerable.Empty<VenueDto>();
        }

        public async Task<VenueDto?> GetVenueByIdAsync(int id)
        {
            var venue = await _repository.Venue.FindByIdAsync(id);

            return _mapper.Map<VenueDto>(venue);
        }

        public async Task<VenueDto?> CreateVenueAsync(VenueForCreateDto venueToCreate)
        {
            ArgumentNullException.ThrowIfNull(nameof(venueToCreate));

            try
            {
                var venueEntity = _mapper.Map<Venue>(venueToCreate);
                var createdVenue = _repository.Venue.Create(venueEntity);
                await _repository.SaveChangesAsync();

                return _mapper.Map<VenueDto>(createdVenue);
            }
            catch (Exception ex)
            {
                _logger.LogError("There was an error creating new Venue", ex);
                throw;
            }
        }

        public async Task UpdateVenueAsync(VenueForUpdateDto venueToUpdate)
        {
            ArgumentNullException.ThrowIfNull(nameof(venueToUpdate));

            try
            {
                var venueEntity = _mapper.Map<Venue>(venueToUpdate);

                _repository.Venue.Update(venueEntity);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an error updating Venue with id: {venueToUpdate.Id}", ex);
                throw;
            }
        }

        public async Task DeleteVenueAsync(int id)
        {
            try
            {
                var venueEntity = await _repository.Venue.FindByIdAsync(id) ??
                    throw new ArgumentException($"Venue with id: {id} does not exist.", nameof(id));

                _repository.Venue.Delete(venueEntity);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an error deleting Venue with id: {id}.", ex);
                throw;
            }
        }
    }
}
