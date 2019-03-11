using System;
using BookingSystem.Queries.Queries.HotelQueries.Queries;

namespace BookingSystem.WebApi.Models
{
    public class HotelsRequestModel
    {
        public string Name { get; set; }
        public DateTime MoveInDate { get; set; }
        public DateTime MoveOutDate { get; set; }
        public bool? IsActive { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public int? RoomSize { get; set; }

        public ListHotelsQuery ToQuery() 
            => new ListHotelsQuery(Name, MoveInDate, MoveOutDate, 
                                   IsActive, CountryId, CityId, RoomSize);
    }
}
