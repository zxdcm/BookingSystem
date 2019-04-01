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

        public async Task<Paged<HotelPreView>> ExecuteAsync(ListHotelsQuery query)
        {
            var rooms = from room in _dataContext.Rooms
                join booking in _dataContext.Bookings on room.RoomId equals booking.RoomId into bookings
                from b in bookings.DefaultIfEmpty()
                where (b == null ||
                       (query.MoveInDate > b.MoveOutDate ||
                        query.MoveInDate < b.MoveOutDate) ||
                       (b.Status == BookingStatus.Failed) ||
                       (b.Status == BookingStatus.Pending &&
                        (b.CreatedDate.AddMinutes(_lockTimeOut) > DateTime.UtcNow)))
                group bookings by new { room.RoomId, room.Quantity, room.Size, room.HotelId }
                into grRooms
                from b in grRooms
                where b.Count() < grRooms.Key.Quantity
                select new { grRooms.Key.RoomId, grRooms.Key.Size, grRooms.Key.HotelId };

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
                join city in _dataContext.Cities
                    on hotel.CityId equals city.CityId
                join country in _dataContext.Countries 
                    on hotel.CountryId equals country.CountryId
                select new HotelPreView()
                {
                    HotelId = hotel.HotelId,
                    Name = hotel.Name,
                    Address = hotel.Address,
                    CountryName = country.Name,
                    CityName = city.Name,
                    IsActive = hotel.IsActive,
                    ImageUrl = hImage.imageUrl
                });
            return await hotels.PaginateAsync(query.PageInfo);
        }
    }
}