using AutoMapper;
using TicketingSystem.Domain.DTOs.Offer;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Domain.Mappings;

public class OfferMapping : Profile
{
    public OfferMapping()
    {
        CreateMap<Offer, OfferDto>();
        CreateMap<OfferDto, Offer>();
        CreateMap<OfferForCreateDto, Offer>();
        CreateMap<OfferForUpdateDto, Offer>();
    }
}
