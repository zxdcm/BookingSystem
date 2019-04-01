using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BookingSystem.ReadPersistence.Utils;

namespace BookingSystem.Queries.Queries.HotelQueries.Queries.ListHotelsQueryUtils
{

    public static class SpCommand
    {
        public static List<SqlParameter> CreateInputParams(ListHotelsQuery query, int lockTime)
        {
            var sqlParams = new List<SqlParameter> 
            {
                new SqlParameter(DbObjects.Name, (object)query.Name ??  DBNull.Value),
                new SqlParameter(DbObjects.IsActive, (object) query.IsActive ?? DBNull.Value),
                new SqlParameter(DbObjects.CityId, (object) query.CityId ?? DBNull.Value),
                new SqlParameter(DbObjects.CountryId, (object) query.CountryId ?? DBNull.Value),
                new SqlParameter(DbObjects.RoomSize, (object) query.RoomSize ?? DBNull.Value),
                new SqlParameter(DbObjects.MoveInDate, query.MoveInDate != DateTime.MinValue ? (object)query.MoveInDate : DBNull.Value),
                new SqlParameter(DbObjects.MoveOutDate, query.MoveOutDate != DateTime.MinValue ? (object)query.MoveOutDate : DBNull.Value),
                new SqlParameter(DbObjects.LockTime, lockTime),
                new SqlParameter(DbObjects.Page, query.PageInfo.Page),
                new SqlParameter(DbObjects.PageSize, query.PageInfo.PageSize),
            };
            return sqlParams;
        }
    }
}
