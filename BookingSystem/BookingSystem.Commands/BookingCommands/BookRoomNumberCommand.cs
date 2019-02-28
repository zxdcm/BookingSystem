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
    public class BookRoomNumberCommand : ICommand<Task<Result>>
    {
        public NewBookingDto Booking { get; }

        public BookRoomNumberCommand (NewBookingDto booking)
        {
            Booking = booking;
        }

        internal sealed class BookRoomNumberCommandHandler : ICommandHandler<BookRoomNumberCommand, Task<Result>>
        {
            private readonly BookingWriteContext _dataContext;

            public BookRoomNumberCommandHandler(BookingWriteContext dataContext)
            {
                _dataContext = dataContext;
            }


            public Task<Result> ExecuteAsync(BookRoomNumberCommand command)
            {
                throw new NotImplementedException();
            }
        }

    }
}
