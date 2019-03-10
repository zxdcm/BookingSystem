namespace BookingSystem.ReadPersistence.ReadModels
{
    public partial class ExtraService
    {
        public ExtraService()
        {

        }

        public int ExtraServiceId { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public bool? IsActive { get; private set; }
        public int HotelId { get; private set; }
    }
}
