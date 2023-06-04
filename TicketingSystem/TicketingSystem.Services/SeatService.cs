using AutoMapper;
using Microsoft.Extensions.Logging;
using TicketingSystem.Domain.DTOs.Seat;
using TicketingSystem.Domain.Entities;
using TicketingSystem.Domain.Interfaces.Repositories;
using TicketingSystem.Domain.Interfaces.Services;

namespace TicketingSystem.Services
{
    public class SeatService : ISeatService
    {
        private readonly ICommonRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<ISeatService> _logger;

        public SeatService(ICommonRepository repository, IMapper mapper, ILogger<ISeatService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<SeatDto>> GetAllSeatsAsync()
        {
            var seats = await _repository.Seat.FindAllAsync();

            return _mapper.Map<IEnumerable<SeatDto>>(seats) ?? Enumerable.Empty<SeatDto>();
        }

        public async Task<SeatDto?> GetSeatByIdAsync(int id)
        {
            var seat = await _repository.Seat.FindByIdAsync(id);

            return _mapper.Map<SeatDto>(seat);
        }

        public async Task<SeatDto?> CreateSeatAsync(SeatForCreateDto seatToCreate)
        {
            ArgumentNullException.ThrowIfNull(nameof(seatToCreate));

            try
            {
                var seatEntity = _mapper.Map<Seat>(seatToCreate);
                var createdSeat = _repository.Seat.Create(seatEntity);
                await _repository.SaveChangesAsync();

                return _mapper.Map<SeatDto>(createdSeat);
            }
            catch (Exception ex)
            {
                _logger.LogError("There was an error creating new Seat", ex);
                throw;
            }
        }

        public async Task UpdateSeatAsync(SeatForUpdateDto seatToUpdate)
        {
            ArgumentNullException.ThrowIfNull(nameof(seatToUpdate));

            try
            {
                var seatEntity = _mapper.Map<Seat>(seatToUpdate);

                _repository.Seat.Update(seatEntity);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an error updating Seat with id: {seatToUpdate.Id}", ex);
                throw;
            }
        }

        public async Task DeleteSeatAsync(int id)
        {
            try
            {
                var seatEntity = await _repository.Seat.FindByIdAsync(id) ??
                    throw new ArgumentException($"Seat with id: {id} does not exist.", nameof(id));

                _repository.Seat.Delete(seatEntity);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an error deleting Seat with id: {id}.", ex);
                throw;
            }
        }
    }
}
