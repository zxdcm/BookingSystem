namespace BookingSystem.ReadPersistence.ReadModels
{
    public partial class City
    {
        public City()
        {

        }

        public int CityId { get; private set; }
        public string Name { get; private set; }
        public int CountryId { get; private set; }
    }
}
