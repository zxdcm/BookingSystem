namespace BookingSystem.Queries.Queries.RoomQueries.Views
{
    public class RoomPreView
    {
        public int RoomId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int HotelId { get; set; }
        public int Quantity { get; set; }
    }
}
