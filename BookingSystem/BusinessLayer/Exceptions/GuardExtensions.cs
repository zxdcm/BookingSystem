using System;
using System.Collections.Generic;
using System.Text;
using Ardalis.GuardClauses;
using DataAccessLayer.Entities;

namespace BusinessLayer.Exceptions
{
    public static class GuardExtensions
    {
        public static void NullHotel(this IGuardClause guardClause, Hotel hotel, int hotelId)
        {
            if (hotel == null)
                throw new HotelNotFoundException(hotelId);
        }
    }
}
