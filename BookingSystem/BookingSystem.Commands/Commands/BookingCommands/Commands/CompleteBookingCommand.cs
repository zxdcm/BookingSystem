using System.Threading.Tasks;
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
    public class CompleteBookingCommand : ICommand<Result>
    {
        public CompleteBookingDto Booking { get; }

        public CompleteBookingCommand(CompleteBookingDto booking)
        {
            Booking = booking;
        }
    }
    public class CompleteBookingCommandHandler : ICommandHandler<CompleteBookingCommand, Result>
    {
        private readonly BookingWriteContext _dataContext;
        private readonly int _lockTimeOut;
        private readonly BookingService _bookingService;

        public CompleteBookingCommandHandler(BookingWriteContext dataContext,
            IBookingConfiguration config, 
            BookingService bookingService)
        {
            _dataContext = dataContext;
            _bookingService = bookingService;
            _lockTimeOut = config.LockTimeOutMinutes;
        }

        public async Task<Result> ExecuteAsync(CompleteBookingCommand command)
        {
            var bookingDto = command.Booking;

            var booking = await _dataContext.Bookings.FindAsync(bookingDto.BookingId);
            if (booking == null)
                return Result.NullEntityError(nameof(Booking), bookingDto.BookingId);

            await _bookingService.CompleteBookingAsync(booking, _lockTimeOut);
            await _dataContext.SaveChangesAsync();

            if (booking.Status == BookingStatus.Failed)
                return Result.Error(string.Format(ErrorsResources.LockTimeOut, _lockTimeOut));

            return Result.Ok(booking.BookingId);
        }
    }
}
