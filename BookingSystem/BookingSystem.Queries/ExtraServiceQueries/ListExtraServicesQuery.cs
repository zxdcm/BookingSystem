using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Views;
using BookingSystem.ReadPersistence;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries.ExtraServiceQueries
{
    public class ListExtraServicesQuery : IQuery<Task<IEnumerable<ExtraServiceView>>>
    {
        
    }

    public class ListExtraServicesQueryHandler : IQueryHandler<ListExtraServicesQuery, Task<IEnumerable<ExtraServiceView>>>
    {
        private readonly BookingReadContext _dataContext;

        public ListExtraServicesQueryHandler(BookingReadContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<ExtraServiceView>> Execute(ListExtraServicesQuery query)
        {
            return await _dataContext.ExtraServices
                .Select(ExtraServiceView.Projection)
                .ToListAsync();
        }
    }
}
