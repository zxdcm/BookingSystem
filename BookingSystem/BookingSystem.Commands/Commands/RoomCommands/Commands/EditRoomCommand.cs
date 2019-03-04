using System.Threading.Tasks;
using AutoMapper;
using BookingSystem.Commands.Commands.RoomCommands.DTOs;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Common.Interfaces;
using BookingSystem.WritePersistence;
using BookingSystem.WritePersistence.WriteModels;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Commands.Commands.RoomCommands.Commands
{
    public class EditRoomCommand : ICommand<Task<Result>>
    {

        public EditedRoomDto Room { get; }

        public EditRoomCommand(EditedRoomDto room)
        {
            Room = room;
        }
    }

    public class EditRoomCommandHandler : ICommandHandler<EditRoomCommand, Task<Result>>
    {
        private readonly BookingWriteContext _dataContext;
        private readonly IMapper _mapper;

        public EditRoomCommandHandler(BookingWriteContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result> Execute(EditRoomCommand command)
        {
            var dto = command.Room;

            var room = await _dataContext.Rooms
                .FirstOrDefaultAsync(r => r.RoomId == dto.RoomId);
            if (room == null)
                return Result.NullEntityError(nameof(Room), dto.RoomId);

            _mapper.Map(dto, room);
            await _dataContext.SaveChangesAsync();
            return Result.Ok();
        }
    }
}
