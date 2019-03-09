namespace BookingSystem.Queries.Queries.HotelQueries.Views
{
    public class HotelPreView
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public bool? IsActive { get; set; }
    }
}
