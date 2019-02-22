using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public partial class ExtraServices
    {
        public ExtraServices()
        {
            BookingExtraServices = new HashSet<BookingExtraServices>();
        }

        public int ExtraServiceId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool? IsAvailable { get; set; }
        public int HotelId { get; set; }

        public virtual Hotels Hotel { get; set; }
        public virtual ICollection<BookingExtraServices> BookingExtraServices { get; set; }
    }
}
