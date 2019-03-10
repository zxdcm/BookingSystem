using System.Threading.Tasks;
using AutoMapper;
using BookingSystem.Commands.Commands.HotelCommands.DTOs;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Common.Interfaces;
using BookingSystem.WritePersistence;
using BookingSystem.WritePersistence.WriteModels;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Commands.Commands.HotelCommands.Commands 
{
    public class AddHotelCommand : ICommand<Result>
    {
        public NewHotelDto Hotel { get; }

        public AddHotelCommand(NewHotelDto hotel)
        {
            Hotel = hotel;
        }
    }
    public class AddHotelCommandHandler : ICommandHandler<AddHotelCommand, Result>
    {
        private readonly BookingWriteContext _dataContext;
        private readonly IMapper _mapper;

        public AddHotelCommandHandler(BookingWriteContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result> ExecuteAsync(AddHotelCommand command)
        {
            var hotelDto = command.Hotel;

            var city = await _dataContext.Cities.FindAsync(hotelDto.CityId); 
            if (city == null)
                return Result.NullEntityError(nameof(City), hotelDto.CityId);

            var hotel = _mapper.Map<Hotel>(hotelDto);
            hotel.CountryId = city.CountryId; 
            _dataContext.Hotels.Add(hotel);

            await _dataContext.SaveChangesAsync();
            return Result.Ok(hotel.HotelId);
        }
    }
}
