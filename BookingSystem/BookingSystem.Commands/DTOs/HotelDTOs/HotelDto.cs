namespace BookingSystem.Commands.DTOs.HotelDTOs
{
    public class HotelDto 
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Address { get; set; }
        public string CountryId { get; set; }
        public string CityId { get; set; }
    }
}
