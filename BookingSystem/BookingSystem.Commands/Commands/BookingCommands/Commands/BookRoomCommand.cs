using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using BookingSystem.Commands.Commands.BookingCommands.DTOs;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Commands.Properties;
using BookingSystem.Common.Interfaces;
using BookingSystem.WritePersistence;
using BookingSystem.WritePersistence.Enums;
using BookingSystem.WritePersistence.WriteModels;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Commands.Commands.BookingCommands.Commands
{
    public class BookRoomCommand : ICommand<Task<Result>>
    {
        public NewBookingDto Booking { get; }

        public BookRoomCommand (NewBookingDto booking)
        {
            Booking = booking;
        }
    }

    public class BookRoomCommandHandler : ICommandHandler<BookRoomCommand, Task<Result>>
    {
        private readonly BookingWriteContext _dataContext;
        private readonly IMapper _mapper;

        public BookRoomCommandHandler(BookingWriteContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result> Execute(BookRoomCommand command)
        {
            var dto = command.Booking;

            var user = await _dataContext.Users.FindAsync(dto.UserId);
            if (user == null)
                return Result.NullEntityError(nameof(User), dto.UserId);

            var room = await _dataContext.Rooms.FindAsync(dto.RoomId);
            if (room == null)
                return Result.NullEntityError(nameof(Room), dto.RoomId);

            Expression<Func<Booking, bool>> condition = //TODO: fix 
                b => (b.RoomId == dto.RoomId && 
                     ((b.MoveInDate < dto.MoveInDate && b.MoveOutDate > dto.MoveOutDate) || //inside 
                     (b.MoveInDate < dto.MoveInDate && b.MoveOutDate > dto.MoveInDate) || //left border
                     (b.MoveInDate > dto.MoveInDate && b.MoveInDate < dto.MoveOutDate))); // right border

            var count = await _dataContext.Bookings.Where(condition).CountAsync();

            if (room.Quantity < count)
                return Result.Error(Errors.NoAvailableRooms);

            var booking = _mapper.Map<Booking>(dto);
            booking.Status = BookingStatus.Pending;
            await _dataContext.Bookings.AddAsync(booking);
            return Result.Ok();
        }
    }
}
