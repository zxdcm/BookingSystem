using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Queries.CountryQueries.Views;

namespace BookingSystem.Queries.Queries.CountryQueries.Queries
{
    public class ListCountriesQuery : IQuery<Task<CountryView>>
    {
        public string CountryNameLike { get; }
        public int Amount { get; }
    }
}
