using System.Threading.Tasks;
using BookingSystem.ApplicationCore.DTOs.ExtraServiceDTOs;
using BookingSystem.ApplicationCore.Interfaces;
using BookingSystem.Commands.Infrastructure;

namespace BookingSystem.Commands.ExtraServiceCommands
{
    public class AddExtraServiceCommand : ICommand<Task<Result>>
    {
        public NewExtraServiceDto ExtraService { get; }

        public AddExtraServiceCommand(NewExtraServiceDto extraService)
        {
            ExtraService = extraService;
        }
    }
}
