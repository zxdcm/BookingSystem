using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public partial class Countries
    {
        public Countries()
        {
            Cities = new HashSet<Cities>();
            Hotels = new HashSet<Hotels>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Cities> Cities { get; set; }
        public virtual ICollection<Hotels> Hotels { get; set; }
    }
}
