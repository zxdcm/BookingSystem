using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Views;
using BookingSystem.ReadPersistence;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries.HotelQueries
{
    public class ListHotelsQuery : IQuery<IQueryable<HotelView>>
    {

    }

    public class ListHotelsQueryHandler : IQueryHandler<ListHotelsQuery, IQueryable<HotelView>>
    {
        private readonly BookingReadContext _dataContext;

        public ListHotelsQueryHandler(BookingReadContext dataContext)
        {
            _dataContext = dataContext;
        }


        public IQueryable<HotelView> Execute(ListHotelsQuery query)
        {
            return _dataContext.Hotels
                .Select(HotelView.PartialProjection);
        }
    }
}
