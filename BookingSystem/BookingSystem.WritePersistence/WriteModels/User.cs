using System.Collections.Generic;

namespace BookingSystem.WritePersistence.WriteModels
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

        public ICollection<Booking> Bookings { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
