using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.ReadPersistence;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries.Queries.BookingQueries.Queries
{
    public class UserCanAccessBookingQuery : IQuery<bool>
    {
        public int BookingId { get; }
        public int UserId { get; }

        public UserCanAccessBookingQuery(int bookingId, int userId)
        {
            BookingId = bookingId;
            UserId = userId;
        }
    }

    public class UserCanAccessBookingQueryHandler : IQueryHandler<UserCanAccessBookingQuery, bool>
    {
        private readonly BookingReadContext _dataContext;

        public UserCanAccessBookingQueryHandler(BookingReadContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> ExecuteAsync(UserCanAccessBookingQuery query)
        {
            return await _dataContext.Bookings
                .AnyAsync(b => b.BookingId == query.BookingId && b.UserId == query.UserId);
        }
    }
}
