namespace BookingSystem.Commands.Commands.RoomCommands.DTOs
{
    public class EditedRoomDto
    {
        public int RoomId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int Quantity { get; set; }
    }
}
