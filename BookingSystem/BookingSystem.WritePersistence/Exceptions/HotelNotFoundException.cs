using System;

namespace BookingSystem.WritePersistence.Exceptions
{
    public class HotelNotFoundException : Exception
    {
        public HotelNotFoundException(int hotelId) : base($"No hotel found with id {hotelId}")
        {

        }
    }
}
