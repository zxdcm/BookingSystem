using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.ReadPersistence.Utils
{
    public class DbObjects
    {
        public const string GetAvailableHotelsSp = "usp_GetAvailableHotels ";

        public const string GetAvailableHotelsSpParams = 
            "@LockTime, @MoveInDate, @MoveOutDate, " +
            "@Name, @IsActive, @CityId, " +
            "@CountryId, @RoomSize, @PageSize, " +
            "@Page, @TotalItems OUTPUT";

        public const string LockTime = "@LockTime";
        public const string MoveInDate = "@MoveIndate";
        public const string MoveOutDate = "@MoveOutDate";
        public const string Name = "@Name";
        public const string IsActive = "@IsActive";
        public const string CityId = "@CityId";
        public const string CountryId = "@CountryId";
        public const string RoomSize = "@RoomSize";
        public const string PageSize = "@PageSize";
        public const string Page = "@Page";
        public const string TotalItems = "@TotalItems";

    }
}
