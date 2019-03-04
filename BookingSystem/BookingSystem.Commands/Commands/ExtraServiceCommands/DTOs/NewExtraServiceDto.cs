namespace BookingSystem.Commands.Commands.ExtraServiceCommands.DTOs
{
    public class NewExtraServiceDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool? IsAvailable { get; set; }
        public int HotelId { get; set; }
    }
}
