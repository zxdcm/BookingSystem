namespace BookingSystem.ApplicationCore.DTOs.RoomDTOs
{
    public class NewRoomDto
    { 
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int HotelId { get; set; }
        public string NumbersRange { get; set; }
    }
}
