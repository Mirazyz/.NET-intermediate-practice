using AutoMapper;
using TicketingSystem.Domain.DTOs.Purchase;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Domain.Mappings;

public class PurchaseMapping : Profile
{
    public PurchaseMapping()
    {
        CreateMap<Purchase, PurchaseDto>();
        CreateMap<PurchaseDto, Purchase>();
        CreateMap<PurchaseForCreateDto, Purchase>();
        CreateMap<PurchaseForUpdateDto, Purchase>();
    }
}
