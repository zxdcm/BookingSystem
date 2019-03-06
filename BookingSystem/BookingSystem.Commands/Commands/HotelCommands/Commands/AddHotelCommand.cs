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
    public class AddHotelCommand : ICommand<Task<Result>>
    {
        public NewHotelDto Hotel { get; }

        public AddHotelCommand(NewHotelDto hotel)
        {
            Hotel = hotel;
        }
    }
    public class AddHotelCommandHandler : ICommandHandler<AddHotelCommand, Task<Result>>
    {
        private readonly BookingWriteContext _dataContext;
        private readonly IMapper _mapper;

        public AddHotelCommandHandler(BookingWriteContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result> Execute(AddHotelCommand command)
        {
            var dto = command.Hotel;

            var city = await _dataContext.Cities
                .FirstOrDefaultAsync(c => c.CityId == dto.CityId && 
                                          c.CountryId == dto.CountryId);
            if (city == null)
                return Result.NullEntityError(nameof(City), dto.CityId);

            var hotel = _mapper.Map<Hotel>(dto);
            await _dataContext.Hotels.AddAsync(hotel);
            await _dataContext.SaveChangesAsync();
            return Result.Ok();
        }
    }
}
