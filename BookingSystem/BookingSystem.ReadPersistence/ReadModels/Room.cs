namespace BookingSystem.ReadPersistence.ReadModels
{
    public partial class Room
    {
        public Room() { }

        public int RoomId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int HotelId { get; set; }
        public int Quantity { get; set; }
        
    }
}
