using System.Threading.Tasks;
using BookingSystem.ApplicationCore.Interfaces;
using BookingSystem.ApplicationCore.Views;

namespace BookingSystem.Queries.HotelQueries
{
    public class HotelDetailsQuery : IQuery<Task<HotelView>>
    {
        public int HotelId { get; }
         

        public HotelDetailsQuery(int hotelId)
        {
            HotelId = hotelId;
        }
    }
}
