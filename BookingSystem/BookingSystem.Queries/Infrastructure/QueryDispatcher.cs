using System;
using BookingSystem.Common.Interfaces;

namespace BookingSystem.Queries.Infrastructure
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _provider;

        public QueryDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public T Dispatch<T>(IQuery<T> query)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            T result = handler.Execute((dynamic)query);
            return result;
        }
    }
}
