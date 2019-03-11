using System;
using BookingSystem.ReadPersistence.Enums;

namespace BookingSystem.ReadPersistence.ReadModels
{
    public class Booking
    {
        public Booking() { }

        public int BookingId { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime MoveInDate { get; private set; }
        public DateTime MoveOutDate { get; private set; }
        public decimal? TotalPrice { get; private set; }
        public BookingStatus Status { get; private set; }
        public int RoomId { get; private set; }
        public int UserId { get; private set; }
    }
}
