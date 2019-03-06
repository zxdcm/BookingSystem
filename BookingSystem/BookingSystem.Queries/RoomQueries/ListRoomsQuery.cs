using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Views;
using BookingSystem.ReadPersistence;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries.RoomQueries
{
    public class ListRoomsQuery : IQuery<Task<RoomView>>
    {
        public int RoomId { get; set; }

        public ListRoomsQuery(int roomId)
        {
            RoomId = roomId;
        }
    }

    public class ListRoomsQueryHandler : IQueryHandler<ListRoomsQuery, Task<IEnumerable<RoomView>>>
    {
        private readonly BookingReadContext _dataContext;

        public ListRoomsQueryHandler(BookingReadContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<RoomView>> Execute(ListRoomsQuery query)
        {
            return await _dataContext.Rooms
                .Select(RoomView.Projection)
                .ToListAsync();
        }
    }
}
