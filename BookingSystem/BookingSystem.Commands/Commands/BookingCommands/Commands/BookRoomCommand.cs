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
        public int UserId { get; }

        public BookRoomCommand (NewBookingDto booking, int userId)
        {
            Booking = booking;
            UserId = userId;
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


        public async Task<Result> ValidateRules(BookRoomCommand command)
        {
            var userId = command.UserId;
            var user = await _dataContext.Users.FindAsync(userId);
            if (user == null)
                return Result.NullEntityError(nameof(User), userId);

            var bookingDto = command.Booking;

            var room = await _dataContext.Rooms.FindAsync(bookingDto.RoomId);
            if (room == null)
                return Result.NullEntityError(nameof(Room), bookingDto.RoomId);


            var result = await _hotelService.HasAvailableRoomAsync(room, bookingDto.MoveInDate, bookingDto.MoveOutDate); 
            if (!result)
                return Result.Error(ErrorsResources.NoAvailableRooms);

            return Result.Ok();
        }


        public async Task<Result> ExecuteAsync(BookRoomCommand command)
        {

            var result = await ValidateRules(command);
            if (!result.IsSuccessful)
                return result;

            var bookingDto = command.Booking;

            var booking = _mapper.Map<Booking>(bookingDto);
            booking.UserId = command.UserId;
            booking.Status = BookingStatus.Pending;

            _dataContext.Bookings.Add(booking);
            await _dataContext.SaveChangesAsync();
            return Result.Ok(booking.BookingId);
        }
    }
}
