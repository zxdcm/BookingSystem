using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.WritePersistence.Enums;
using BookingSystem.WritePersistence.WriteModels;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.WritePersistence.Services
{
    public class BookingService
    {
        private readonly BookingWriteContext _dataContext;

        public BookingService(BookingWriteContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CompleteBookingAsync(Booking booking, int lockTimeOut)
        {
            if (booking.Status == BookingStatus.Completed)
                return;

            var extraServicesPrice = await _dataContext.BookingExtraServices
                .Where(b => b.BookingId == booking.BookingId)
                .Join(_dataContext.ExtraServices,
                    b => b.ExtraServiceId,
                    e => e.ExtraServiceId, (b, e) => e.Price)
                .SumAsync();

            decimal roomPricePerNight = await _dataContext.Rooms
                .Where(r => r.RoomId == booking.RoomId)
                .Select(x => x.Price)
                .FirstOrDefaultAsync();

            int rentDays = (booking.MoveOutDate - booking.MoveInDate).Days;
            decimal totalRoomPrice = roomPricePerNight * rentDays;
            booking.TotalPrice = extraServicesPrice + totalRoomPrice;

            if (booking.Status == BookingStatus.Pending && (DateTime.UtcNow - booking.CreatedDate).TotalMinutes < lockTimeOut)
            {
                booking.Status = BookingStatus.Completed;
            }
            else
            {
                booking.Status = BookingStatus.Failed;
            }
        }

        public async Task<bool> CanBookExtraServicesAsync(Booking booking, IEnumerable<int> extraServicesIds)
        {
            var hotelId = await _dataContext.Rooms
                .Where(r => r.RoomId == booking.RoomId)
                .Select(r => r.HotelId)
                .FirstOrDefaultAsync();

            if (hotelId == 0)
                return false;

            var availableServicesAmount = await _dataContext.ExtraServices
                .Where(se => se.HotelId == hotelId &&
                             extraServicesIds.Contains(se.ExtraServiceId) && 
                             se.IsActive == true)
                .CountAsync();

            return availableServicesAmount == extraServicesIds.Count();
        }
    }
}
