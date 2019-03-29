using System;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Queries.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.WebApi.Utils
{
    public static class PaginationExtension
    {
        public static IServiceProvider _provider;

        public static async Task<Paged<T>> PaginateAsync<T>(this IQueryable<T> query, PageInfo pageInfo)
        {
            var totalItems = await query.CountAsync();
            var totalPages = (totalItems + pageInfo.PageSize - 1) / pageInfo.PageSize;
            var queryResult = await query.Skip(pageInfo.PageSize * pageInfo.Page).Take(pageInfo.PageSize).ToArrayAsync();
            var newPageInfo = new PageInfo()
                {Page = pageInfo.Page,
                PageSize = pageInfo.PageSize,
                    TotalPages = totalPages};
            return new Paged<T>(){ Items = queryResult, PageInfo = newPageInfo};
        }
    }
}
