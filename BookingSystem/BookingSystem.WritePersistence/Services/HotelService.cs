using System;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.WritePersistence.WriteModels;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.WritePersistence.Services
{
    public class HotelService 
    {
        private readonly BookingWriteContext _dataContext;

        public HotelService(BookingWriteContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> HasAvailableRoomAsync(Room room, DateTime moveInDate, DateTime moveOutDate)
        {
            // Count amount of overlapping time periods. 
            var count = await _dataContext.Bookings
                .Where(b => b.RoomId == room.RoomId &&  
                            (moveInDate < b.MoveOutDate) && 
                            (moveOutDate > b.MoveInDate))
                .CountAsync();

            return room.Quantity > count;
        }

    }
}
