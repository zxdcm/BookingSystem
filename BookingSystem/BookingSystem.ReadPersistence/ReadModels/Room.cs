namespace BookingSystem.ReadPersistence.ReadModels
{
    public partial class Room
    {
        public Room() { }

        public int RoomId { get; private set; }
        public decimal Price { get; private set; }
        public string Name { get; private set; }
        public int Size { get; private set; }
        public int HotelId { get; private set; }
        public int Quantity { get; private set; }
        
    }
}
