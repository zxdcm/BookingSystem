using System.Threading.Tasks;
using AutoMapper;
using BookingSystem.ApplicationCore.Entities.WriteModels;
using BookingSystem.ApplicationCore.Interfaces;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.WritePersistence;

namespace BookingSystem.Commands.HotelCommands
{
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
