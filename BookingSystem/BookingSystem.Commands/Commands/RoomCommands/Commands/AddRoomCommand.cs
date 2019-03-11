using System.Threading.Tasks;
using AutoMapper;
using BookingSystem.Commands.Commands.RoomCommands.DTOs;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Common.Interfaces;
using BookingSystem.WritePersistence;
using BookingSystem.WritePersistence.WriteModels;

namespace BookingSystem.Commands.Commands.RoomCommands.Commands
{
    public class AddRoomCommand : ICommand<Result>
    {
        public NewRoomDto Room { get; }

        public AddRoomCommand(NewRoomDto room)
        {
            Room = room;
        }
    }
    public class AddRoomCommandHandler : ICommandHandler<AddRoomCommand, Result>
    {
        private readonly BookingWriteContext _dataContext;
        private readonly IMapper _mapper;

        public AddRoomCommandHandler(BookingWriteContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result> ExecuteAsync(AddRoomCommand command)
        {
            var roomDto = command.Room;

            var hotel = await _dataContext.Hotels.FindAsync(roomDto.HotelId);
            if (hotel == null)
                return Result.NullEntityError(nameof(Hotel), roomDto.HotelId);

            var room = _mapper.Map<Room>(roomDto);

            _dataContext.Rooms.Add(room);
            await _dataContext.SaveChangesAsync();
            return Result.Ok(room.RoomId);
        }
    }
}
