using System;
using System.Threading.Tasks;
using Autofac;
using BookingSystem.Common.Interfaces;

namespace BookingSystem.Queries.Infrastructure
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _provider;
        private readonly IComponentContext _context;



        public QueryDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<T> DispatchAsync<T>(IQuery<T> query)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);   
            dynamic handler = _provider.GetService(handlerType);

            T result = await handler.ExecuteAsync((dynamic)query);
            return result;
        }
    }
}
