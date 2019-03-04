namespace BookingSystem.Commands.Commands.RoomCommands.DTOs
{
    public class NewRoomDto
    { 
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int HotelId { get; set; }
        public int Quantity { get; set; }
    }
}
