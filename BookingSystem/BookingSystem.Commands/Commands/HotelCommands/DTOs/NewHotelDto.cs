namespace BookingSystem.Commands.Commands.HotelCommands.DTOs
{
    public class NewHotelDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public bool? IsActive { get; set; }
    }
}
