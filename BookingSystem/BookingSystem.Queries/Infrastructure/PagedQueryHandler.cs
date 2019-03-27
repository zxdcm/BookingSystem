using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries.Infrastructure
{
    public class Paged<T>
    {
        public PageInfo Paging { get; set; }
        public T[] Items { get; set; }
    }

    public class PageInfo
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; } = 20;
        public int TotalPages { get; set; }
    }

    public class PagedQuery<TQuery, TItem> : IQuery<Paged<TItem>>
        where TQuery : IQuery<IQueryable<TItem>>
    {
        public TQuery Query { get; set; }
        public PageInfo PageInfo { get; set; }
    }

    public class PagedQueryHandler<TQuery, TItem> : IQueryHandler<PagedQuery<TQuery, TItem>, Paged<TItem>>
           where TQuery : IQuery<IQueryable<TItem>>
    {
        private readonly IQueryHandler<TQuery, IQueryable<TItem>> _handler;

        public PagedQueryHandler(IQueryHandler<TQuery, IQueryable<TItem>> handler)
        {
            _handler = handler;
        }

        public async Task<Paged<TItem>> ExecuteAsync(PagedQuery<TQuery, TItem> query)
        {
            var paging = query.PageInfo ?? new PageInfo();
            IQueryable<TItem> queryItems = await  _handler.ExecuteAsync(query.Query);
            var items = await queryItems.Skip(paging.PageIndex * paging.PageSize)
                .Take(paging.PageSize).ToArrayAsync();
            var totalItems = await queryItems.CountAsync();
            paging.TotalPages = totalItems / paging.PageSize;
            return new Paged<TItem>
            {
                Items = items,
                Paging = paging
            };
        }
    }
}
