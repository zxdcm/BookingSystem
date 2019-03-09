namespace BookingSystem.Queries.Queries.ExtraServiceQueries.Views
{
    public class ExtraServiceView
    {
        public int ExtraServiceId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool? IsActive { get; set; }
        public int HotelId { get; set; }
    }
}
