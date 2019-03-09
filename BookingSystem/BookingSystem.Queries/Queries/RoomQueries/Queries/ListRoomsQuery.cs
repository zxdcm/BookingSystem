using System.Linq;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Queries.RoomQueries.Views;
using BookingSystem.ReadPersistence;

namespace BookingSystem.Queries.Queries.RoomQueries.Queries
{
    public class ListRoomsQuery : IQuery<IQueryable<RoomView>>
    {
        public ListRoomsQuery()
        {

        }
    }

    public class ListRoomsQueryHandler : IQueryHandler<ListRoomsQuery, IQueryable<RoomView>>
    {
        private readonly BookingReadContext _dataContext;

        public ListRoomsQueryHandler(BookingReadContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<RoomView> Execute(ListRoomsQuery query)
        {
            var rooms = from room in _dataContext.Rooms
                        select new RoomView()
                        {
                            RoomId = room.RoomId,
                            Price = room.Price,
                            Name = room.Name,
                            HotelId = room.HotelId,
                            Quantity = room.Quantity,
                            Size = room.Size,
                        };
            return rooms;
        }
    }
}
