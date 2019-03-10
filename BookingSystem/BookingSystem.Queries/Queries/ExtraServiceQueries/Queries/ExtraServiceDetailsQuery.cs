using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Queries.ExtraServiceQueries.Views;
using BookingSystem.ReadPersistence;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries.Queries.ExtraServiceQueries.Queries
{
    public class ExtraServiceDetailsQuery : IQuery<ExtraServiceView>
    {
        public int ExtraServiceId { get; }

        public ExtraServiceDetailsQuery(int extraServiceId)
        {
            ExtraServiceId = extraServiceId;
        }
    }

    public class ExtraServiceDetailsQueryHandler : IQueryHandler<ExtraServiceDetailsQuery, ExtraServiceView>
    {

        private readonly BookingReadContext _dataContext;

        public ExtraServiceDetailsQueryHandler(BookingReadContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ExtraServiceView> ExecuteAsync(ExtraServiceDetailsQuery query)
        {
            var services = from service in _dataContext.ExtraServices
                select new ExtraServiceView()
                {
                    ExtraServiceId = service.ExtraServiceId,
                    HotelId = service.HotelId,
                    IsActive = service.IsActive,
                    Name = service.Name,
                    Price = service.Price,
                };
            return await services
                .FirstOrDefaultAsync(s => s.ExtraServiceId == query.ExtraServiceId);

        }
    }
}
