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
    public class HotelImageQuery : IQuery<string> 
    {
        public int HotelId { get; }

        public HotelImageQuery(int hotelId)
        {
            HotelId = hotelId;
        }
    }

    public class HotelImageQueryHandler : IQueryHandler<HotelImageQuery, string>
    {
        private readonly BookingReadContext _dataContext;

        public HotelImageQueryHandler(BookingReadContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<string> ExecuteAsync(HotelImageQuery query)
        {
            var queryResult = from image in _dataContext.Images
                join hotelImage in _dataContext.HotelImages on image.ImageId equals hotelImage.ImageId
                              where hotelImage.HotelId == query.HotelId
                select image.Url;
            return queryResult.FirstOrDefaultAsync();
        }
    }
}
