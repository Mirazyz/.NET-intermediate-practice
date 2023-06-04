using AutoMapper;
using Microsoft.Extensions.Logging;
using TicketingSystem.Domain.DTOs.Purchase;
using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Domain.Interfaces.Services;

namespace TicketingSystem.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly ICommonRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<IPurchaseService> _logger;

        public PurchaseService(ICommonRepository repository, IMapper mapper, ILogger<IPurchaseService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<PurchaseDto>> GetAllPurchasesAsync()
        {
            var purchases = await _repository.Purchase.FindAllAsync();

            return _mapper.Map<IEnumerable<PurchaseDto>>(purchases) ?? Enumerable.Empty<PurchaseDto>();
        }

        public async Task<PurchaseDto?> GetPurchaseByIdAsync(int id)
        {
            var purchase = await _repository.Purchase.FindByIdAsync(id);

            return _mapper.Map<PurchaseDto>(purchase);
        }

        public async Task<PurchaseDto?> CreatePurchaseAsync(PurchaseForCreateDto purchaseToCreate)
        {
            ArgumentNullException.ThrowIfNull(nameof(purchaseToCreate));

            try
            {
                var purchaseEntity = _mapper.Map<Purchase>(purchaseToCreate);
                var createdPurchase = _repository.Purchase.Create(purchaseEntity);
                await _repository.SaveChangesAsync();

                return _mapper.Map<PurchaseDto>(createdPurchase);
            }
            catch (Exception ex)
            {
                _logger.LogError("There was an error creating new Purchase", ex);
                throw;
            }
        }

        public async Task UpdatePurchaseAsync(PurchaseForUpdateDto purchaseToUpdate)
        {
            ArgumentNullException.ThrowIfNull(nameof(purchaseToUpdate));

            try
            {
                var purchaseEntity = _mapper.Map<Purchase>(purchaseToUpdate);

                _repository.Purchase.Update(purchaseEntity);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an error updating Purchase with id: {purchaseToUpdate.Id}", ex);
                throw;
            }
        }

        public async Task DeletePurchaseAsync(int id)
        {
            try
            {
                var purchaseEntity = await _repository.Purchase.FindByIdAsync(id) ??
                    throw new ArgumentException($"Purchase with id: {id} does not exist.", nameof(id));

                _repository.Purchase.Delete(purchaseEntity);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an error deleting Purchase with id: {id}.", ex);
                throw;
            }
        }
    }
}
