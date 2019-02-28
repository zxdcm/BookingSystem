using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Commands.DTOs.BookingDTOs;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Common.Interfaces;
using BookingSystem.WritePersistence;

namespace BookingSystem.Commands.BookingCommands
{
    public class EditBookingCommand : ICommand<Task<Result>>
    {
        public EditedBookingDto Booking { get; }

        public EditBookingCommand(EditedBookingDto booking)
        {
            Booking = booking;
        }

        internal sealed class EditBookingCommandHandler : ICommandHandler<EditBookingCommand, Task<Result>>
        {
            private readonly BookingWriteContext _dataContext;

            public EditBookingCommandHandler(BookingWriteContext dataContext)
            {
                _dataContext = dataContext;
            }

            public Task<Result> ExecuteAsync(EditBookingCommand command)
            {
                throw new NotImplementedException();
            }
        }
    }
}
