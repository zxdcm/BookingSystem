using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Queries.RoomQueries.Views;
using BookingSystem.ReadPersistence;

namespace BookingSystem.Queries.Queries.RoomQueries.Queries
{
    public class ListRoomsQuery : IQuery<IQueryable<RoomView>>
    {
        public int HotelId { get; }

        public ListRoomsQuery(int hotelId)
        {
            HotelId = hotelId;
        }
    }

    public class ListRoomsQueryHandler : IQueryHandler<ListRoomsQuery, IQueryable<RoomView>>
    {
        private readonly BookingReadContext _dataContext;

        public ListRoomsQueryHandler(BookingReadContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<IQueryable<RoomView>> ExecuteAsync(ListRoomsQuery query)
        {
            var rooms = from room in _dataContext.Rooms
                        where room.HotelId == query.HotelId
                        select new RoomView()
                        {
                            RoomId = room.RoomId,
                            Price = room.Price,
                            Name = room.Name,
                            HotelId = room.HotelId,
                            Quantity = room.Quantity,
                            Size = room.Size,
                        };
            return Task.FromResult(rooms);
        }
    }
}
