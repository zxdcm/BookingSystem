﻿namespace BusinessLayer.DTOs.HotelDTOs
{
    public class CreateHotelDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public bool? IsActive { get; set; }
    }
}
