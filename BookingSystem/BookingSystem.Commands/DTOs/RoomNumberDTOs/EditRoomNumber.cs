namespace BookingSystem.Commands.DTOs.RoomNumberDTOs
{
    public class EditRoomNumber
    {
        public int RoomNumberId { get; set; }
        public bool? IsAvailable { get; set; }
        public int Number { get; set; }
        public int RoomId { get; set; }
    }
}
