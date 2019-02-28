using System.Collections.Generic;

namespace BookingSystem.ApplicationCore.Entities.WriteModels
{
    public partial class ExtraService
    {
        public ExtraService()
        {
            BookingExtraServices = new HashSet<BookingExtraService>();
        }

        public int ExtraServiceId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool? IsAvailable { get; set; }
        public int HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<BookingExtraService> BookingExtraServices { get; set; }
    }
}
