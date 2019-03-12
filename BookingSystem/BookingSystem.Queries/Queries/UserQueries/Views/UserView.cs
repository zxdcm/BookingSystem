using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Queries.Queries.UserQueries.Views
{
    public class UserView
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }

    }
}
