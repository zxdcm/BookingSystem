﻿using System;
using BookingSystem.ReadPersistence.Enums;

namespace BookingSystem.Queries.Queries.BookingQueries.Views
{
    public class BookingView
    {
        public int BookingId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime MoveInDate { get; set; }
        public DateTime MoveOutDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public BookingStatus Status { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
    }
}
