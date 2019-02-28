using System.Threading.Tasks;
using BookingSystem.ApplicationCore.DTOs.HotelDTOs;
using BookingSystem.ApplicationCore.Interfaces;
using BookingSystem.Commands.Infrastructure;

namespace BookingSystem.Commands.HotelCommands 
{
    public class AddHotelCommand : ICommand<Task<Result>>
    {
        public NewHotelDto Hotel { get; }

        public AddHotelCommand(NewHotelDto hotel)
        {
            Hotel = hotel;
        }
    }
}
