using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace BusinessLayer.DTOs.HotelDTOs
{
    public class HotelDetailsDto : IRequest<Unit>
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Address { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
    }
}
