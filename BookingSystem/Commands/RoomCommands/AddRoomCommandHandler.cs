using System;
using System.Threading.Tasks;
using BookingSystem.ApplicationCore.Interfaces;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.WritePersistence;

namespace BookingSystem.Commands.RoomCommands
{
    public class AddRoomCommandHandler : ICommandHandler<AddRoomCommand, Task<Result>>
    {
        private readonly BookingWriteContext _dataContext;

        public AddRoomCommandHandler(BookingWriteContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<Result> ExecuteAsync(AddRoomCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
