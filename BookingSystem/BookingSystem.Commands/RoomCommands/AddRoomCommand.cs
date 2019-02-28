using System;
using System.Threading.Tasks;
using BookingSystem.Commands.DTOs.RoomDTOs;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Common.Interfaces;
using BookingSystem.WritePersistence;

namespace BookingSystem.Commands.RoomCommands
{
    public class AddRoomCommand : ICommand<Task<Result>>
    {
        public NewRoomDto Room { get; }

        public AddRoomCommand(NewRoomDto room)
        {
            Room = room;
        }

        internal sealed class AddRoomCommandHandler : ICommandHandler<AddRoomCommand, Task<Result>>
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
}
