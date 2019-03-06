using System.Threading.Tasks;
using AutoMapper;
using BookingSystem.Commands.Commands.BookingCommands.DTOs;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Commands.Properties;
using BookingSystem.Common.Interfaces;
using BookingSystem.WritePersistence;
using BookingSystem.WritePersistence.Services;
using BookingSystem.WritePersistence.WriteModels;

namespace BookingSystem.Commands.Commands.BookingCommands.Commands
{
    public class BookExtraServicesCommand : ICommand<Result>
    {
        public BookExtraServicesDto Booking { get; }

        public BookExtraServicesCommand(BookExtraServicesDto booking)
        {
            Booking = booking;
        }
    }

    public class BookExtraServicesCommandHandler : ICommandHandler<BookExtraServicesCommand, Result>
    {
        private readonly BookingWriteContext _dataContext;
        private readonly IMapper _mapper;
        private readonly BookingService _bookingService;

        public BookExtraServicesCommandHandler(BookingWriteContext dataContext, 
            IMapper mapper,
            BookingService bookingService)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _bookingService = bookingService;
        }

        public async Task<Result> ExecuteAsync(BookExtraServicesCommand command)
        {
            var bookingDto = command.Booking;

            var booking = await _dataContext.Bookings.FindAsync(bookingDto.BookingId);
            if (booking == null)
                return Result.NullEntityError(nameof(Booking), bookingDto.BookingId);

            var result = await _bookingService.CanBookExtraServicesAsync(booking, bookingDto.ExtraServicesIds);
            if (!result)
                return Result.Error(ErrorsResources.InvalidExtraServices);

            _mapper.Map(bookingDto, booking);
            await _dataContext.SaveChangesAsync();
            return Result.Ok(booking.BookingId);
        }
    }
}
