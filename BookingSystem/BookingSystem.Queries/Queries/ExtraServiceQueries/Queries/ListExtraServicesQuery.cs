using System.Linq;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Queries.ExtraServiceQueries.Views;
using BookingSystem.ReadPersistence;

namespace BookingSystem.Queries.Queries.ExtraServiceQueries.Queries
{
    public class ListExtraServicesQuery : IQuery<IQueryable<ExtraServiceView>>
    {
        
    }

    public class ListExtraServicesQueryHandler : IQueryHandler<ListExtraServicesQuery, IQueryable<ExtraServiceView>>
    {
        private readonly BookingReadContext _dataContext;

        public ListExtraServicesQueryHandler(BookingReadContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<ExtraServiceView> Execute(ListExtraServicesQuery query)
        {
            var services = from service in _dataContext.ExtraServices
                select new ExtraServiceView()
                {
                    ExtraServiceId = service.ExtraServiceId,
                    HotelId = service.HotelId,
                    Name = service.Name,
                    IsActive = service.IsActive,
                    Price = service.Price,
                };
            return services;
        }
    }
}
