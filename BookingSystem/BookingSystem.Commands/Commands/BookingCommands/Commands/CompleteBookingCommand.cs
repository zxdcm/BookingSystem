using System;
using System.Linq;
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
using Microsoft.Extensions.Configuration;

namespace BookingSystem.Commands.Commands.BookingCommands.Commands
{
    public class CompleteBookingCommand : ICommand<Task<Result>>
    {
        public CompleteBookingDto Booking { get; }

        public CompleteBookingCommand(CompleteBookingDto booking)
        {
            Booking = booking;
        }
    }
    public class CompleteBookingCommandHandler : ICommandHandler<CompleteBookingCommand, Task<Result>>
    {
        private readonly BookingWriteContext _dataContext;
        private readonly int _lockTimeOut;
        private readonly IMapper _mapper;

        public CompleteBookingCommandHandler(BookingWriteContext dataContext,
            IMapper mapper, 
            IConfiguration config)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _lockTimeOut = config.GetValue("BookingRules:TimeOutMinutes", 30);
        }

        public async Task<Result> Execute(CompleteBookingCommand command)
        {
            var dto = command.Booking;

            var booking = await _dataContext.Bookings.FindAsync(dto.BookingId);

            if (booking == null)
                return Result.NullEntityError(nameof(Booking), dto.BookingId);

            var extraServicesQuery = _dataContext.ExtraServices //Todo: check that extraServices belongs to hotel
                .Where(x => dto.ExtraServicesIds.Any(id => id == x.ExtraServiceId) && x.IsAvailable == true);

            var extraServicesAmount = await extraServicesQuery.CountAsync();
            if (extraServicesAmount != dto.ExtraServicesIds.Count())
                return Result.Error(Errors.InvalidExtraServices);

            //Todo: Replace with methods
            _mapper.Map(dto, booking);

            booking.CompleteBooking(_lockTimeOut);
            if (booking.Status == BookingStatus.Failed)
            {
                await _dataContext.SaveChangesAsync();
                return Result.Error(string.Format(Errors.LockTimeOut, _lockTimeOut));
            }

            booking.TotalPrice = await extraServicesQuery.Select(x => x.Price).SumAsync();
            await _dataContext.SaveChangesAsync();
            return Result.Ok();
        }
    }
}
