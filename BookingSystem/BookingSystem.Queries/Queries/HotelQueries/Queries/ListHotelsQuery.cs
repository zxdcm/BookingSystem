using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Infrastructure;
using BookingSystem.Queries.Queries.HotelQueries.Queries.ListHotelsQueryUtils;
using BookingSystem.Queries.Queries.HotelQueries.Views;
using BookingSystem.ReadPersistence;
using BookingSystem.ReadPersistence.Enums;
using BookingSystem.ReadPersistence.ReadModels;
using Microsoft.EntityFrameworkCore;
using BookingSystem.ReadPersistence.Utils;

namespace BookingSystem.Queries.Queries.HotelQueries.Queries
{
    public class ListHotelsQuery : IQuery<Paged<HotelPreView>>
    {
        public string Name { get; }
        public DateTime MoveInDate { get; }
        public DateTime MoveOutDate { get; }
        public bool? IsActive { get; }
        public int? CountryId { get; }
        public int? CityId { get; }
        public int? RoomSize { get; }
        public PageInfo PageInfo { get; }

        public ListHotelsQuery(string name, DateTime moveIntDate, DateTime moveOutDate,
            bool? isActive, int? countryId, int? cityId, int? roomSize, PageInfo pageInfo)
        {
            Name = name;
            MoveInDate = moveIntDate;
            MoveOutDate = moveOutDate;
            IsActive = isActive;
            CountryId = countryId;
            CityId = cityId;
            RoomSize = roomSize;
            PageInfo = pageInfo;
        }

    }

    public class ListHotelsQueryHandler : IQueryHandler<ListHotelsQuery, Paged<HotelPreView>>
    {
        private readonly BookingReadContext _dataContext;
        private readonly int _lockTimeOut;

        public ListHotelsQueryHandler(BookingReadContext dataContext,
            IBookingConfiguration config)
        {
            _dataContext = dataContext;
            _lockTimeOut = config.LockTimeOutMinutes;
        }

        public Task<Paged<HotelPreView>> ExecuteAsync(ListHotelsQuery query)
        {
            query.PageInfo.PageSize = query.PageInfo.PageSize > 0 ? query.PageInfo.PageSize : 1;
            query.PageInfo.Page = query.PageInfo.Page > 0 ? query.PageInfo.Page : 1;

            string sqlQuery = DbActions.ExecuteGetAvailableHotelsSp;
            var sqlParams = SpCommand.CreateInputParams(query, _lockTimeOut);
            var totalPagesParam = new SqlParameter
            {
                ParameterName = DbObjects.TotalPages,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };
            sqlParams.Add(totalPagesParam);

            var hotels = _dataContext.Query<SpListHotelDetails>().FromSql(sqlQuery, sqlParams.ToArray()).ToList(); //Requires params [] not collection.

            int totalPages = totalPagesParam.Value as int? ?? default(int);

            return Task.FromResult(new Paged<HotelPreView>()
            {
                Items = hotels.Select(h => new HotelPreView()
                {
                    HotelId = h.HotelId,
                    Name = h.Name,
                    Address = h.Address,
                    CityName = h.CityName,
                    CountryName = h.CountryName,
                    IsActive = h.IsActive,
                    ImageUrl = h.ImageUrl
                }).ToArray(),
                PageInfo = new PageInfo()
                {
                    Page = query.PageInfo.Page,
                    PageSize = query.PageInfo.PageSize,
                    TotalPages = totalPages
                }
            });
        }
    }
}