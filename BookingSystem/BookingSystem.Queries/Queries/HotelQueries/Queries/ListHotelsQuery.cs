using System;
using System.Linq;
using System.Threading.Tasks;
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
        public string Name { get; }
        public DateTime MoveInDate { get; }
        public DateTime MoveOutDate { get; }
        public bool? IsActive { get; }
        public int? CountryId { get; }
        public int? CityId { get; }
        public int? RoomSize { get; }

        public ListHotelsQuery(string name, DateTime moveIntDate, DateTime moveOutDate,
            bool? isActive, int? countryId, int? cityId, int? roomSize)
        {
            Name = name;
            MoveInDate = moveIntDate;
            MoveOutDate = moveOutDate;
            IsActive = isActive;
            CountryId = countryId;
            CityId = cityId;
            RoomSize = roomSize;
        }

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
                where ((query.MoveInDate > b.MoveOutDate || query.MoveOutDate < b.MoveInDate) ||
                       (b.Status == BookingStatus.Failed) ||
                       (b.Status == BookingStatus.Pending && (b.CreatedDate.AddMinutes(_lockTimeOut) > DateTime.UtcNow)))
                where (room.Quantity > bookings.Count())
                select room;
            return rooms;
        }

        public Task<IQueryable<HotelPreView>> ExecuteAsync(ListHotelsQuery query)
        {
            
            var rooms = GetAvailableRooms(query);

            var filteredRooms = rooms
                .WhereIf(query.RoomSize.HasValue, room => room.Size == query.RoomSize);

            var filteredHotels = _dataContext.Hotels
                .WhereIf(!string.IsNullOrWhiteSpace(query.Name), h => h.Name.StartsWith(query.Name))
                .WhereIf(query.IsActive.HasValue, h => h.IsActive == query.IsActive)
                .WhereIf(query.CityId.HasValue, h => h.CityId == query.CityId)
                .WhereIf(query.CountryId.HasValue, h => h.CountryId == query.CountryId);

            // TODO: ask. EF cant execute join.. 
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
            return Task.FromResult(hotels);
        }
    }
}
