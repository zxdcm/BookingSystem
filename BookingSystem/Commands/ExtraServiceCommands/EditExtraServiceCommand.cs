using System.Threading.Tasks;
using BookingSystem.ApplicationCore.DTOs.ExtraServiceDTOs;
using BookingSystem.ApplicationCore.Interfaces;
using BookingSystem.Commands.Infrastructure;

namespace BookingSystem.Commands.ExtraServiceCommands
{
    public class EditExtraServiceCommand : ICommand<Result>, ICommand<Task<Result>>
    {
        public EditedExtraServiceDto ExtraService{ get; }

        public EditExtraServiceCommand(EditedExtraServiceDto extraService)
        {
            ExtraService = extraService;
        }
    }
}
