using AutoMapper;
using TicketingSystem.Domain.DTOs.Customer;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Domain.Mappings;

public class CustomerMapping : Profile
{
    public CustomerMapping()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerDto, Customer>();
        CreateMap<CustomerForCreateDto, Customer>();
        CreateMap<CustomerForUpdateDto, Customer>();
    }
}
