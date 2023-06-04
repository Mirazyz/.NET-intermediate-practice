using AutoMapper;
using Microsoft.Extensions.Logging;
using TicketingSystem.Domain.DTOs.Price;
using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Domain.Interfaces.Services;

namespace TicketingSystem.Services
{
    public class PriceService : IPriceService
    {
        private readonly ICommonRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<IPriceService> _logger;

        public PriceService(ICommonRepository repository, IMapper mapper, ILogger<IPriceService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<PriceDto>> GetAllPricesAsync()
        {
            var prices = await _repository.Price.FindAllAsync();

            return _mapper.Map<IEnumerable<PriceDto>>(prices) ?? Enumerable.Empty<PriceDto>();
        }

        public async Task<PriceDto?> GetPriceByIdAsync(int id)
        {
            var price = await _repository.Price.FindByIdAsync(id);

            return _mapper.Map<PriceDto>(price);
        }

        public async Task<PriceDto?> CreatePriceAsync(PriceForCreateDto priceToCreate)
        {
            ArgumentNullException.ThrowIfNull(nameof(priceToCreate));

            try
            {
                var priceEntity = _mapper.Map<Price>(priceToCreate);
                var createdPrice = _repository.Price.Create(priceEntity);
                await _repository.SaveChangesAsync();

                return _mapper.Map<PriceDto>(createdPrice);
            }
            catch (Exception ex)
            {
                _logger.LogError("There was an error creating new Price", ex);
                throw;
            }
        }

        public async Task UpdatePriceAsync(PriceForUpdateDto priceToUpdate)
        {
            ArgumentNullException.ThrowIfNull(nameof(priceToUpdate));

            try
            {
                var priceEntity = _mapper.Map<Price>(priceToUpdate);

                _repository.Price.Update(priceEntity);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an error updating price with id: {priceToUpdate.Id}", ex);

                throw;
            }
        }

        public async Task DeletePriceAsync(int id)
        {
            try
            {
                var priceEntity = await _repository.Price.FindByIdAsync(id) ??
                    throw new ArgumentException($"Price with id: {id} does not exist.", nameof(id));

                _repository.Price.Delete(priceEntity);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an error deleting Price with id: {id}.", ex);
                throw;
            }
        }
    }
}
