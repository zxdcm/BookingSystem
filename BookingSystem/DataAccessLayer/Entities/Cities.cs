using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public partial class Cities
    {
        public Cities()
        {
            Hotels = new HashSet<Hotels>();
        }

        public int CityId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public virtual Countries Country { get; set; }
        public virtual ICollection<Hotels> Hotels { get; set; }
    }
}
