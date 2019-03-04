using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Common.Interfaces;
using BookingSystem.Queries.Views;

namespace BookingSystem.Queries.CountryQueries
{
    public class ListCountriesQuery : IQuery<Task<CountryView>>
    {
        public string CountryNameLike { get; }
        public int Amount { get; }
    }
}
