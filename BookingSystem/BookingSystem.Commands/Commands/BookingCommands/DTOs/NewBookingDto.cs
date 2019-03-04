using System;

namespace BookingSystem.Commands.Commands.BookingCommands.DTOs
{
    public class NewBookingDto
    {
        public DateTime MoveInDate { get; set; }
        public DateTime MoveOutDate { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
    }
}
