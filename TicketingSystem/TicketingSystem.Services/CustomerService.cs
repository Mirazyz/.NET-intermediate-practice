using AutoMapper;
using TicketingSystem.Domain.DTOs.Customer;
using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Domain.Interfaces.Services;

namespace TicketingSystem.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICommonRepository _repository;
        private readonly IMapper _mapper;

        public CustomerService(ICommonRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _repository.Customer.FindAllAsync();

            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task<CustomerDto?> GetCustomerByIdAsync(int id)
        {
            var customer = await _repository.Customer.FindByIdAsync(id);

            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto?> CreateCustomerAsync(CustomerForCreateDto customer)
        {
            ArgumentNullException.ThrowIfNull(customer);

            var customerEntity = _mapper.Map<Customer>(customer);

            var createdCustomer = _repository.Customer.Create(customerEntity);
            await _repository.SaveChangesAsync();

            return _mapper.Map<CustomerDto>(createdCustomer);
        }

        public async Task UpdateCustomerAsync(CustomerForUpdateDto customer)
        {
            ArgumentNullException.ThrowIfNull(customer);

            var customerEntity = _mapper.Map<Customer>(customer);

            _repository.Customer.Update(customerEntity);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _repository.Customer.FindByIdAsync(id) ??
                throw new ArgumentException($"Customer with id: {id} does not exist.");

            _repository.Customer.Delete(customer);
            await _repository.SaveChangesAsync();
        }
    }
}