using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Commands.Commands.AccountCommands.DTOs
{
    public class SignUpDto
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
