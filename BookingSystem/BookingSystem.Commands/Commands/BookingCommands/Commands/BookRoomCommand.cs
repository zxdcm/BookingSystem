using System.Threading.Tasks;
using AutoMapper;
using BookingSystem.Commands.Commands.BookingCommands.DTOs;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Commands.Properties;
using BookingSystem.Common.Interfaces;
using BookingSystem.WritePersistence;
using BookingSystem.WritePersistence.Enums;
using BookingSystem.WritePersistence.Services;
using BookingSystem.WritePersistence.WriteModels;

namespace BookingSystem.Commands.Commands.BookingCommands.Commands
{
    public class BookRoomCommand : ICommand<Result>
    {
        public NewBookingDto Booking { get; }

        public BookRoomCommand (NewBookingDto booking)
        {
            Booking = booking;
        }
    }

    public class BookRoomCommandHandler : ICommandHandler<BookRoomCommand, Result>
    {
        private readonly BookingWriteContext _dataContext;
        private readonly IMapper _mapper;
        private readonly HotelService _hotelService;

        public BookRoomCommandHandler(BookingWriteContext dataContext,
            IMapper mapper, 
            HotelService hotelService)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _hotelService = hotelService;
        }


        public async Task<Result> ValidateRules(NewBookingDto dto)
        {
            var user = await _dataContext.Users.FindAsync(dto.UserId);
            if (user == null)
                return Result.NullEntityError(nameof(User), dto.UserId);

            var room = await _dataContext.Rooms.FindAsync(dto.RoomId);
            if (room == null)
                return Result.NullEntityError(nameof(Room), dto.RoomId);


            var result = await _hotelService.HasAvailableRoomAsync(room, dto.MoveInDate, dto.MoveOutDate); 
            if (!result)
                return Result.Error(ErrorsResources.NoAvailableRooms);

            return Result.Ok();
        }


        public async Task<Result> ExecuteAsync(BookRoomCommand command)
        {
            var bookingDto = command.Booking; 

            var result = await ValidateRules(bookingDto);
            if (!result.IsSuccessful)
                return result;

            var booking = _mapper.Map<Booking>(bookingDto); 
            booking.Status = BookingStatus.Pending;

            _dataContext.Bookings.Add(booking);
            await _dataContext.SaveChangesAsync();
            return Result.Ok(booking.BookingId);
        }
    }
}
