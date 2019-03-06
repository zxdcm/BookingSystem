using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Queries.RoomQueries.Views;
using BookingSystem.ReadPersistence;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries.Queries.RoomQueries.Queries
{
    public class RoomDetailsQuery : IQuery<Task<RoomPreView>>
    {
        public int RoomId { get; }

        public RoomDetailsQuery(int roomId)
        {
            RoomId = roomId;
        }
    }

    public class RoomDetailsQueryHandler : IQueryHandler<RoomDetailsQuery, Task<RoomView>>
    {
        private readonly BookingReadContext _dataContext;

        public RoomDetailsQueryHandler(BookingReadContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<RoomView> Execute(RoomDetailsQuery query)
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
            return await rooms.FirstOrDefaultAsync(r => r.RoomId == query.RoomId);
        }
    }
}
