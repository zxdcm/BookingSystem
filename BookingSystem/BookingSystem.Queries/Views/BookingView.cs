using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using BookingSystem.ReadPersistence.Enums;
using BookingSystem.ReadPersistence.ReadModels;

namespace BookingSystem.Queries.Views
{
    public class BookingView
    {
        public int BookingId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime MoveInDate { get; set; }
        public DateTime MoveOutDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public string Status { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }

        public static Expression<Func<Booking, BookingView>> Projection 
            => booking => new BookingView()
            {
                BookingId = booking.BookingId,
                CreatedDate = booking.CreatedDate,
                MoveInDate = booking.MoveInDate,
                MoveOutDate = booking.MoveOutDate,
                Status = ((BookingStatus)booking.Status).ToString(),
            };

    }
}
