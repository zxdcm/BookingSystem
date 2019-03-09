using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Queries.BookingQueries.Views;
using BookingSystem.ReadPersistence;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries.Queries.BookingQueries.Queries
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

        public BookingDetailsQueryHandler(BookingReadContext dataContext)
        {
            _dataContext = dataContext;
        }


        public Task<BookingView> Execute(BookingDetailsQuery query)
        {
            return _dataContext.Bookings
                .Select(b => new BookingView()
                {
                    BookingId = b.BookingId,
                    RoomId = b.RoomId,
                    Status = b.Status,
                    CreatedDate = b.CreatedDate,
                    MoveInDate = b.MoveInDate,
                    MoveOutDate = b.MoveOutDate,
                    TotalPrice = b.TotalPrice,
                    UserId = b.UserId,
                })
                .FirstOrDefaultAsync(h => h.BookingId == query.BookingId);
        }
    }
}
