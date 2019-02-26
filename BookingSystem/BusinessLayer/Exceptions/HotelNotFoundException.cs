using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Exceptions
{
    public class HotelNotFoundException : Exception
    {
        public HotelNotFoundException(int hotelId) : base($"No hotel found with id {hotelId}")
        {

        }
    }
}
