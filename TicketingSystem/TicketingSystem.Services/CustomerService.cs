using AutoMapper;
using Microsoft.Extensions.Logging;
using TicketingSystem.Domain.DTOs.Customer;
using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Exceptions;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Domain.Interfaces.Services;

namespace TicketingSystem.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICommonRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<ICustomerService> _logger;

        public CustomerService(ICommonRepository repository, IMapper mapper, ILogger<CustomerService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _repository.Customer.FindAllAsync();

            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task<CustomerDto?> GetCustomerByIdAsync(int id)
        {
            var customer = await _repository.Customer.FindByIdAsync(id);

            if (customer is null)
            {
                throw new EntityDoesNotExistException($"Customer with id: {id} does not exist.");
            }

            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto?> CreateCustomerAsync(CustomerForCreateDto customer)
        {
            ArgumentNullException.ThrowIfNull(customer);

            try
            {
                var customerEntity = _mapper.Map<Customer>(customer);

                var createdCustomer = _repository.Customer.Create(customerEntity);
                await _repository.SaveChangesAsync();

                return _mapper.Map<CustomerDto>(createdCustomer);
            }
            catch (Exception ex)
            {
                _logger.LogError("There was an error creating customer", ex);
                throw;
            }
        }

        public async Task UpdateCustomerAsync(CustomerForUpdateDto customer)
        {
            ArgumentNullException.ThrowIfNull(customer);

            try
            {
                var customerEntity = _mapper.Map<Customer>(customer);

                _repository.Customer.Update(customerEntity);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while updating Customer with id: {customer.Id}", ex);
            }
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _repository.Customer.FindByIdAsync(id) ??
                throw new ArgumentException($"Customer with id: {id} does not exist.", nameof(id));

            _repository.Customer.Delete(customer);
            await _repository.SaveChangesAsync();
        }
    }
}