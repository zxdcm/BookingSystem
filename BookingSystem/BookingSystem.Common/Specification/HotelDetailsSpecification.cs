using BookingSystem.WritePersistence.WriteModels;

namespace BookingSystem.Common.Specification
{
    public class HotelDetailsSpecification : BaseSpecification<Hotel>
    {
        public HotelDetailsSpecification(int hotelId) : base(x => x.HotelId == hotelId)
        {
            AddInclude(x => x.HotelImages);
            AddInclude(x => x.City);
            AddInclude(x => x.Country);
        }
    }
}