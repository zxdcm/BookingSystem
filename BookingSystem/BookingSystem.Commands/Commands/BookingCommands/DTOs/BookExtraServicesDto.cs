using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Commands.Commands.BookingCommands.DTOs
{
    public class BookExtraServicesDto
    {
        public int BookingId { get; set; }
        public IEnumerable<int> ExtraServicesIds { get; set; }
    }
}
