using System;

namespace BookingSystem.Common.Exceptions
{
    public class HotelNotFoundException : Exception
    {
        public HotelNotFoundException(int hotelId) : base($"No hotel found with id {hotelId}")
        {

        }
    }
}
