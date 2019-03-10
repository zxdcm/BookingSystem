using System;
using System.Collections.Generic;
using System.Text;
using BookingSystem.Common.Utils;
using BookingSystem.WritePersistence.WriteModels;

namespace BookingSystem.Common.Interfaces
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string hash, string providedPassword);
    } 

}
