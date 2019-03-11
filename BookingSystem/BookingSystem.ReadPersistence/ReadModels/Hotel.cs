namespace BookingSystem.ReadPersistence.ReadModels
{
    public partial class Hotel
    {
        public Hotel()
        {

        }

        public int HotelId { get; private set;}
        public string Name { get; private set;}
        public bool? IsActive { get; private set;}
        public string Address { get; private set;}
        public int CountryId { get; private set;}
        public int CityId { get; private set;}

    }
}
