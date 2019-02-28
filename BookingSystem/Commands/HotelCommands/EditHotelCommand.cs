using System.Threading.Tasks;
using BookingSystem.ApplicationCore.DTOs.HotelDTOs;
using BookingSystem.ApplicationCore.Interfaces;
using BookingSystem.Commands.Infrastructure;

namespace BookingSystem.Commands.HotelCommands
{
    public class EditHotelCommand : BaseCommand<EditedHotelDto>, ICommand<Task<Result>>
    {
        public EditedHotelDto Hotel { get; }

        public EditHotelCommand(EditedHotelDto hotel)
        {
            Hotel = hotel;
        }
    }
}
