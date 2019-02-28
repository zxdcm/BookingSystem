using System;
using System.Threading.Tasks;
using BookingSystem.Commands.DTOs.RoomDTOs;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Common.Interfaces;
using BookingSystem.WritePersistence;

namespace BookingSystem.Commands.RoomCommands
{
    public class EditRoomCommand : ICommand<Task<Result>>
    {

        public EditedRoomDto Room { get; }

        public EditRoomCommand(EditedRoomDto room)
        {
            Room = room;
        }

        internal sealed class EditRoomCommandHandler : ICommandHandler<EditRoomCommand, Task<Result>>
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
}
