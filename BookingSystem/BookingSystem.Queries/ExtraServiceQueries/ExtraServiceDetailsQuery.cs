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
    public class ExtraServiceDetailsQuery : IQuery<Task<ExtraServiceView>>
    {
        public int ExtraServiceId { get; }

        public ExtraServiceDetailsQuery(int extraServiceId)
        {
            ExtraServiceId = extraServiceId;
        }
    }

    public class ExtraServiceDetailsQueryHandler : IQueryHandler<ExtraServiceDetailsQuery, Task<ExtraServiceView>>
    {

        private readonly BookingReadContext _dataContext;

        public ExtraServiceDetailsQueryHandler(BookingReadContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<ExtraServiceView> Execute(ExtraServiceDetailsQuery query)
        {
            return  _dataContext.ExtraServices
                .Select(ExtraServiceView.Projection)
                .FirstOrDefaultAsync(service => service.ExtraServiceId == query.ExtraServiceId);
        }
    }
}
