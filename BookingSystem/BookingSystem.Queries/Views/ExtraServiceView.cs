using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using BookingSystem.ReadPersistence.ReadModels;

namespace BookingSystem.Queries.Views
{
    public class ExtraServiceView
    {
        public int ExtraServiceId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool? IsAvailable { get; set; }
        public int HotelId { get; set; }

        public static Expression<Func<ExtraService, ExtraServiceView>> Projection
            => service => new ExtraServiceView
            {
                ExtraServiceId = service.ExtraServiceId,
                HotelId = service.HotelId,
                Price = service.Price,
                Name = service.Name,
                IsAvailable = service.IsAvailable,
            };
    }
}
