using AutoMapper;
using Microsoft.Extensions.Logging;
using TicketingSystem.Domain.DTOs.Offer;
using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Domain.Interfaces.Services;

namespace TicketingSystem.Services
{
    public class OfferService : IOfferService
    {
        private readonly ICommonRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<IOfferService> _logger;

        public OfferService(ICommonRepository repository, IMapper mapper, ILogger<IOfferService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<OfferDto>> GetAllOffersAsync()
        {
            var offers = await _repository.Offer.FindAllAsync();

            return _mapper.Map<IEnumerable<OfferDto>>(offers) ?? Enumerable.Empty<OfferDto>();
        }

        public async Task<OfferDto?> GetOfferByIdAsync(int id)
        {
            var offer = await _repository.Offer.FindByIdAsync(id);

            return _mapper.Map<OfferDto>(offer);
        }

        public async Task<OfferDto?> CreateOfferAsync(OfferForCreateDto offerToCreate)
        {
            ArgumentNullException.ThrowIfNull(nameof(offerToCreate));

            try
            {
                var offerEntity = _mapper.Map<Offer>(offerToCreate);
                var createdOffer = _repository.Offer.Create(offerEntity);
                await _repository.SaveChangesAsync();

                return _mapper.Map<OfferDto>(createdOffer);
            }
            catch (Exception ex)
            {
                _logger.LogError("There was an error creating new Offer", ex);
                throw;
            }
        }

        public async Task UpdateOfferAsync(OfferForUpdateDto offerToUpdate)
        {
            ArgumentNullException.ThrowIfNull(nameof(offerToUpdate));

            try
            {
                var offerEntity = _mapper.Map<Offer>(offerToUpdate);

                _repository.Offer.Update(offerEntity);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an error updating offer with id: {offerToUpdate.Id}", ex);

                throw;
            }
        }

        public async Task DeleteOfferAsync(int id)
        {
            try
            {
                var entity = await _repository.Offer.FindByIdAsync(id) ??
                    throw new ArgumentException($"Offer with id: {id} does not exist.", nameof(id));

                _repository.Offer.Delete(entity);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an error deleting offer with id: {id}.", ex);
                throw;
            }
        }
    }
}
