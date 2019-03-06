using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Views;
using BookingSystem.ReadPersistence;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries.HotelQueries
{
    public class HotelDetailsQuery : IQuery<Task<HotelView>>
    {
        public int HotelId { get; }
         
        public HotelDetailsQuery(int hotelId)
        {
            HotelId = hotelId;
        }
    }

    public class HotelDetailsQueryHandler : IQueryHandler<HotelDetailsQuery, Task<HotelView>>
    {
        private readonly BookingReadContext _dataContext;

        public HotelDetailsQueryHandler(BookingReadContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<HotelView> Execute(HotelDetailsQuery query)
        {
//            return _dataContext.Hotels
//                .Select(HotelView.FullProjection)
//                .FirstOrDefaultAsync(hotel => hotel.HotelId == query.HotelId);

            return _dataContext.Hotels
                .Select(hotel => new HotelView
                {
                    HotelId = hotel.HotelId,
                    Name = hotel.Name,
                    Address = hotel.Address,
                    CountryName = hotel.Country.Name,
                    CityName = hotel.City.Name,
                    IsActive = hotel.IsActive,
                    HotelImagesIds = _dataContext.HotelImages.Select(image => image.ImageId),
                    ExtraServices = _dataContext.ExtraServices.Select(service => new ExtraServiceView()
                    {
                        ExtraServiceId = service.ExtraServiceId,
                        HotelId = service.HotelId,
                        IsAvailable = service.IsAvailable,
                        Name = service.Name,
                        Price = service.Price
                    }),
                    Rooms = _dataContext.Rooms.Select(room => new RoomView()
                    {
                        RoomId = room.RoomId,
                        Price = room.Price,
                        Name = room.Name,
                        HotelId = room.HotelId,
                        Quantity = room.Quantity,
                        Size = room.Size,
                        RoomImagesIds = _dataContext.RoomsImages.Select(image => image.ImageId),
                    }), 
                })
                .FirstOrDefaultAsync(hotel => hotel.HotelId == query.HotelId);
        }
    }
}
