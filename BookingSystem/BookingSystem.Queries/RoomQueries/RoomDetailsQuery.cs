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
    public class RoomDetailsQuery : IQuery<RoomView>
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


        public Task<RoomView> Execute(RoomDetailsQuery query)
        {
            return _dataContext.Rooms
                .Select(RoomView.Projection)
                .FirstOrDefaultAsync(r => r.RoomId == query.RoomId);
        }
    }
}
