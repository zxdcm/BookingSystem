using System.Threading.Tasks;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Common.Interfaces;
using BookingSystem.WritePersistence;
using BookingSystem.WritePersistence.WriteModels;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Commands.Commands.HotelCommands.Commands
{
    public class DeleteHotelCommand : ICommand<Task<Result>>
    {
        public int HotelId { get; set; }

        public DeleteHotelCommand(int hotelId)
        {
            HotelId = hotelId;
        }
    }
    
    public class DeleteHotelCommandHandler : ICommandHandler<DeleteHotelCommand, Task<Result>>
    {
        private readonly BookingWriteContext _dataContext;

        public DeleteHotelCommandHandler(BookingWriteContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result> Execute(DeleteHotelCommand command)
        {
            var hotel = await _dataContext.Hotels.FindAsync(command.HotelId);
            if (hotel == null)
                return Result.NullEntityError(nameof(Hotel), command.HotelId);
            hotel.IsActive = false;
            await _dataContext.SaveChangesAsync();
            return Result.Ok();
        }
    }
}
