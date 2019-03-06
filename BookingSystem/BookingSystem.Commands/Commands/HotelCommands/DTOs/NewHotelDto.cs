namespace BookingSystem.Commands.Commands.HotelCommands.DTOs
{
    public class NewHotelDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public bool? IsActive { get; set; }
        //public List<int> Images { get; set; }
        //public List<NewExtraServiceDto> ExtraService { get; set; }
    }
}
