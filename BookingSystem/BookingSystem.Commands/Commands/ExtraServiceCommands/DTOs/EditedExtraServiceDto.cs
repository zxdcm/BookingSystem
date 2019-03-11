namespace BookingSystem.Commands.Commands.ExtraServiceCommands.DTOs
{
    public class EditedExtraServiceDto
    {
        public int ExtraServiceId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool? IsActive { get; set; }
    }
}
