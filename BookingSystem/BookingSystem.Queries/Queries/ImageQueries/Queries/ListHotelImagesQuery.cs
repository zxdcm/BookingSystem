using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.ReadPersistence;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries.Queries.ImageQueries.Queries
{

    public class ListHotelImagesQuery : IQuery<IEnumerable<string>>
    {
        public int HotelId { get; }

        public ListHotelImagesQuery(int hotelId)
        {
            HotelId = hotelId;
        }
    }

    public class ListHotelImagesQueryHandler : IQueryHandler<ListHotelImagesQuery, IEnumerable<string>>
    {
        private readonly BookingReadContext _dataContext;

        public ListHotelImagesQueryHandler(BookingReadContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<string>> ExecuteAsync(ListHotelImagesQuery query)
        {
            var queryResult = from image in _dataContext.Images
                join hotelImage in _dataContext.HotelImages on image.ImageId equals hotelImage.ImageId
                where hotelImage.HotelId == query.HotelId
                select image.Url;
            return await queryResult.ToListAsync();
        }
    }
}
