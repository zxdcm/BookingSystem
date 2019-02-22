using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public partial class Users
    {
        public Users()
        {
            Bookings = new HashSet<Bookings>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}
