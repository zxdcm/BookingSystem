using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Views;
using BookingSystem.ReadPersistence;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries.BookingQueries
{
    public class BookingDetailsQuery : IQuery<Task<BookingView>>
    {
        public int BookingId { get; }

        public BookingDetailsQuery(int bookingId)
        {
            BookingId = bookingId;
        }
    }

    public class BookingDetailsQueryHandler : IQueryHandler<BookingDetailsQuery, Task<BookingView>>
    {
        private readonly BookingReadContext _dataContext;
        private readonly IMapper _mapper;

        public BookingDetailsQueryHandler(BookingReadContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }


        public Task<BookingView> Execute(BookingDetailsQuery query)
        {
            return _dataContext.Bookings.Select(BookingView.Projection)
                .FirstOrDefaultAsync(b => b.BookingId == query.BookingId);
        }
    }
}
