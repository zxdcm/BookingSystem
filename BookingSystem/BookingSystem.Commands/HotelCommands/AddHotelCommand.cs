using System.Threading.Tasks;
using AutoMapper;
using BookingSystem.Commands.DTOs.HotelDTOs;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Common.Interfaces;
using BookingSystem.WritePersistence;
using BookingSystem.WritePersistence.WriteModels;

namespace BookingSystem.Commands.HotelCommands 
{
    public class AddHotelCommand : ICommand<Task<Result>>
    {
        public NewHotelDto Hotel { get; }

        public AddHotelCommand(NewHotelDto hotel)
        {
            Hotel = hotel;
        }

        public class AddHotelCommandHandler : ICommandHandler<AddHotelCommand, Task<Result>>
        {
            private readonly BookingWriteContext _dataContext;

            public AddHotelCommandHandler(BookingWriteContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Result> ExecuteAsync(AddHotelCommand command)
            {
                var dto = command.Hotel;
                var hotel = Mapper.Map<Hotel>(dto);
                await _dataContext.Hotels.AddAsync(hotel);
                await _dataContext.SaveChangesAsync();
                return Result.Ok();
            }
        }
    }
}
