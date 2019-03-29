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
    public class ListHotelsQuery : IQuery<Paged<HotelPreView>>
    {
        public string Name { get; }
        public DateTime MoveInDate { get; }
        public DateTime MoveOutDate { get; }
        public bool? IsActive { get; }
        public int? CountryId { get; }
        public int? CityId { get; }
        public int? RoomSize { get; }
        public PageInfo PageInfo { get; }

        public ListHotelsQuery(string name, DateTime moveIntDate, DateTime moveOutDate,
            bool? isActive, int? countryId, int? cityId, int? roomSize, PageInfo pageInfo)
        {
            Name = name;
            MoveInDate = moveIntDate;
            MoveOutDate = moveOutDate;
            IsActive = isActive;
            CountryId = countryId;
            CityId = cityId;
            RoomSize = roomSize;
            PageInfo = pageInfo;
        }

    }

    public class ListHotelsQueryHandler : IQueryHandler<ListHotelsQuery, Paged<HotelPreView>>
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
                select room;

            return rooms;
//                        from b in bookings
//                        where ((query.MoveInDate > b.MoveOutDate || query.MoveOutDate < b.MoveInDate) ||
//                               (b.Status == BookingStatus.Failed) ||
//                               (b.Status == BookingStatus.Pending && (b.CreatedDate.AddMinutes(_lockTimeOut) > DateTime.UtcNow)))
//                        where (room.Quantity > bookings.Count())
//                        select room;
            return rooms;
        }


        public async Task<Paged<HotelPreView>> ExecuteAsync(ListHotelsQuery query)
        {
            
            var rooms = GetAvailableRooms(query);

            var filteredRooms = rooms
                .WhereIf(query.RoomSize.HasValue, room => room.Size == query.RoomSize);

            var roomsHotelsIds = filteredRooms.Select(r => r.HotelId).Distinct();

            var filteredHotels = _dataContext.Hotels
                .WhereIf(!string.IsNullOrWhiteSpace(query.Name), h => h.Name.StartsWith(query.Name))
                .WhereIf(query.IsActive.HasValue, h => h.IsActive == query.IsActive)
                .WhereIf(query.CityId.HasValue, h => h.CityId == query.CityId)
                .WhereIf(query.CountryId.HasValue, h => h.CountryId == query.CountryId);
       

            var images = from image in _dataContext.Images
                join hotelImage in _dataContext.HotelImages on image.ImageId equals hotelImage.ImageId
                group image.Url by hotelImage.HotelId
                into grImages
                select new { HotelId = grImages.Key, imageUrl = grImages.FirstOrDefault() };

            var hotels = (from hotel in filteredHotels
                join hotelId in roomsHotelsIds
                    on hotel.HotelId equals hotelId
                join image in images
                    on hotel.HotelId equals image.HotelId into jImages
                from hImage in jImages.DefaultIfEmpty()
                select new HotelPreView()
                {
                    HotelId = hotel.HotelId,
                    Name = hotel.Name,
                    Address = hotel.Address,
                    CountryName = hotel.Name,
                    CityName = hotel.Name,
                    IsActive = hotel.IsActive,
                    ImageUrl = hImage.imageUrl
                });
            return await hotels.PaginateAsync(query.PageInfo);
            //return Task.FromResult(hotels);
        }
    }
}
