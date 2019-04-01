using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;

namespace BookingSystem.Queries.Queries.RoomQueries.Queries
{
    public class ListRoomSizesQuery: IQuery<IEnumerable<int>>
    {
        public ListRoomSizesQuery()
        {
            
        }
    }

    public class ListRoomSizesQueryHandler : IQueryHandler<ListRoomSizesQuery, IEnumerable<int>>
    {
        public int MaxRoomSize { get; }

        public ListRoomSizesQueryHandler(IBookingConfiguration config)
        {
            MaxRoomSize = config.MaxRoomSize;
        }

        public Task<IEnumerable<int>> ExecuteAsync(ListRoomSizesQuery query)
        {
            return Task.FromResult(Enumerable.Range(1, MaxRoomSize));
        }
    }
}
