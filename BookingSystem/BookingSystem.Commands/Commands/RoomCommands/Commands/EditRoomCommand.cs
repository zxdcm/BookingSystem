using System.Threading.Tasks;
using AutoMapper;
using BookingSystem.Commands.Commands.RoomCommands.DTOs;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Common.Interfaces;
using BookingSystem.WritePersistence;
using BookingSystem.WritePersistence.WriteModels;

namespace BookingSystem.Commands.Commands.RoomCommands.Commands
{
    public class EditRoomCommand : ICommand<Result>
    {

        public EditedRoomDto Room { get; }

        public EditRoomCommand(EditedRoomDto room)
        {
            Room = room;
        }
    }

    public class EditRoomCommandHandler : ICommandHandler<EditRoomCommand, Result>
    {
        private readonly BookingWriteContext _dataContext;
        private readonly IMapper _mapper;

        public EditRoomCommandHandler(BookingWriteContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result> ExecuteAsync(EditRoomCommand command)
        {
            var roomDto = command.Room;

            var room = await _dataContext.Rooms.FindAsync(roomDto.RoomId);
            if (room == null)
                return Result.NullEntityError(nameof(Room), roomDto.RoomId);

            _mapper.Map(roomDto, room);

            await _dataContext.SaveChangesAsync();
            return Result.Ok(room.RoomId);
        }
    }
}
