using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Queries.Infrastructure
{
    public static class PaginationExtension
    {

        public static async Task<Paged<T>> PaginateAsync<T>(this IQueryable<T> query, PageInfo pageInfo)
        {
            var totalItems = await query.CountAsync();
            var totalPages = (totalItems + pageInfo.PageSize - 1) / pageInfo.PageSize;
            var queryResult = await query.Skip(pageInfo.PageSize * (pageInfo.Page - 1)).Take(pageInfo.PageSize).ToArrayAsync();
            var newPageInfo = new PageInfo()
            {
                Page = pageInfo.Page == 0 ? 1 : pageInfo.Page,
                PageSize = pageInfo.PageSize,
                TotalPages = totalPages
            };
            return new Paged<T>() { Items = queryResult, PageInfo = newPageInfo };
        }
    }
}
