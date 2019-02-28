using System.Collections.Generic;
using BookingSystem.Commands.DTOs.ExtraServiceDTOs;

namespace BookingSystem.Commands.DTOs.HotelDTOs
{
    public class EditedHotelDto
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public string CityId { get; set; }
        public bool? IsActive { get; set; }
        public List<EditedExtraServiceDto> ExtraServices { get; set; }
    }
}
