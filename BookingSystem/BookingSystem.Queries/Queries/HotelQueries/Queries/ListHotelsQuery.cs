using System;
using System.Linq;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Infrastructure;
using BookingSystem.Queries.Queries.HotelQueries.Views;
using BookingSystem.ReadPersistence;
using BookingSystem.ReadPersistence.Enums;
using BookingSystem.ReadPersistence.ReadModels;

namespace BookingSystem.Queries.Queries.HotelQueries.Queries
{
    public class ListHotelsQuery : IQuery<IQueryable<HotelPreView>>
    {
        public bool? IsActive { get; set; }
        public string Name { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public int? RoomSize { get; set; }
        public DateTime MoveIntDate { get; set; }
        public DateTime MoveOutDate { get; set; }
    }

    public class ListHotelsQueryHandler : IQueryHandler<ListHotelsQuery, IQueryable<HotelPreView>>
    {
        private readonly BookingReadContext _dataContext;
        private readonly int _lockTimeOut;

        public ListHotelsQueryHandler(BookingReadContext dataContext,
            IBookingConfiguration config)
        {
            _dataContext = dataContext;
            _lockTimeOut = config.LockTimeOutMinutes;
        }

        private IQueryable<Room> GetAvailableRooms(ListHotelsQuery query)
        {
            var rooms = from room in _dataContext.Rooms
                join booking in _dataContext.Bookings
                    on room.RoomId equals booking.RoomId into bookings
                from b in bookings.DefaultIfEmpty()
                where ((query.MoveIntDate > b.MoveOutDate || query.MoveOutDate < b.MoveInDate) ||
                       (b.Status == BookingStatus.Failed) ||
                       (b.Status == BookingStatus.Pending && (b.CreatedDate.AddMinutes(_lockTimeOut) > DateTime.UtcNow)))
                where (room.Quantity > bookings.Count())
                select room;
            return rooms;
        }

        public IQueryable<HotelPreView> Execute(ListHotelsQuery query)
        {

            var rooms = GetAvailableRooms(query);

            var filteredRooms = rooms
                .WhereIf(query.RoomSize.HasValue, room => room.Size == query.RoomSize);

            var filteredHotels = _dataContext.Hotels
                .WhereIf(query.IsActive.HasValue, h => h.IsActive == query.IsActive)
                .WhereIf(query.CityId.HasValue, h => h.CityId == query.CityId)
                .WhereIf(query.CountryId.HasValue, h => h.CountryId == query.CountryId);

            var hotels = from hotel in filteredHotels
                join room in filteredRooms
                    on hotel.HotelId equals room.HotelId
                select new HotelPreView()
                {
                    HotelId = hotel.HotelId,
                    Name = hotel.Name,
                    Address = hotel.Address,
                    CountryName = hotel.Name,
                    CityName = hotel.Name,
                    IsActive = hotel.IsActive,
                };
            return hotels;
        }
    }
}
