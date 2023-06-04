using AutoMapper;
using TicketingSystem.Domain.DTOs.Price;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Domain.Mappings;

public class PriceMapping : Profile
{
    public PriceMapping()
    {
        CreateMap<Price, PriceDto>();
        CreateMap<PriceDto, Price>();
        CreateMap<PriceForCreateDto, Price>();
        CreateMap<PriceForUpdateDto, Price>();
    }
}
