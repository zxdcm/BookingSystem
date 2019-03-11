namespace BookingSystem.Commands.Commands.HotelCommands.DTOs
{
    public class EditedHotelDto
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public bool? IsActive { get; set; }
    }
}
