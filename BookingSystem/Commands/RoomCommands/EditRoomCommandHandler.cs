using System;
using System.Threading.Tasks;
using BookingSystem.ApplicationCore.Interfaces;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.WritePersistence;

namespace BookingSystem.Commands.RoomCommands
{
    public class EditRoomCommandHandler : ICommandHandler<EditRoomCommand, Task<Result>>
    {
        private readonly BookingWriteContext _dataContext;

        public EditRoomCommandHandler(BookingWriteContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<Result> ExecuteAsync(EditRoomCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
