using System.Collections.Generic;

namespace BookingSystem.ApplicationCore.Entities.ReadModels
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
