using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Commands.Commands.HotelCommands.DTOs
{
    public class EditedHotelExtraServicesDto
    {
        public int HotelId { get; set; }
        public IEnumerable<int> NewExtraServices { get; set; }
    }
}
