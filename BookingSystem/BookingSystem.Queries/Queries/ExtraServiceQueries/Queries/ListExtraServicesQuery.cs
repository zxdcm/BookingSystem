using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Queries.ExtraServiceQueries.Views;
using BookingSystem.ReadPersistence;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries.Queries.ExtraServiceQueries.Queries
{
    public class ListExtraServicesQuery : IQuery<IQueryable<ExtraServiceView>>
    {
        public int HotelId { get; set; }
    }

    public class ListExtraServicesQueryHandler : IQueryHandler<ListExtraServicesQuery, IQueryable<ExtraServiceView>>
    {
        private readonly BookingReadContext _dataContext;

        public ListExtraServicesQueryHandler(BookingReadContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<IQueryable<ExtraServiceView>> ExecuteAsync(ListExtraServicesQuery query)
        {
            var services = from service in _dataContext.ExtraServices
                           where service.HotelId == query.HotelId
                select new ExtraServiceView()
                {
                    ExtraServiceId = service.ExtraServiceId,
                    HotelId = service.HotelId,
                    Name = service.Name,
                    IsActive = service.IsActive,
                    Price = service.Price,
                };
            return Task.FromResult(services);
        }
    }
}
