using AutoMapper;
using TicketingSystem.Domain.DTOs.Seat;
using TicketingSystem.Domain.Entities;

namespace TicketingSystem.Domain.Mappings;

public class SeatMapping : Profile
{
    public SeatMapping()
    {
        CreateMap<Seat, SeatDto>();
        CreateMap<SeatDto, Seat>();
        CreateMap<SeatForCreateDto, Seat>();
        CreateMap<SeatForUpdateDto, Seat>();
    }
}
