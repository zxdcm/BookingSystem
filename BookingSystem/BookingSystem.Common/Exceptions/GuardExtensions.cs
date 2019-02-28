using Ardalis.GuardClauses;
using BookingSystem.WritePersistence.WriteModels;

namespace BookingSystem.Common.Exceptions
{
    public static class GuardExtensions
    {
        public static void NullHotel(this IGuardClause guardClause, Hotel hotel, int hotelId)
        {
            if (hotel == null)
                throw new Exceptions.HotelNotFoundException(hotelId);
        }
    }
}
