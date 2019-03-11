using System;
using System.Collections.Generic;
using BookingSystem.WritePersistence.Enums;

namespace BookingSystem.WritePersistence.WriteModels
{
    public partial class Booking
    {
        public Booking()
        {
            BookingExtraServices = new HashSet<BookingExtraService>();
        }

        public int BookingId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime MoveInDate { get; set; }
        public DateTime MoveOutDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public BookingStatus Status { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }

        public Room Room { get; set; }
        public User User { get; set; }
        public ICollection<BookingExtraService> BookingExtraServices { get; set; }
    }
}
