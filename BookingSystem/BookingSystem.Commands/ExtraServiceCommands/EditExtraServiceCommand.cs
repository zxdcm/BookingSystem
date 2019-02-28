using System;
using System.Threading.Tasks;
using BookingSystem.Commands.DTOs.ExtraServiceDTOs;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Common.Interfaces;
using BookingSystem.WritePersistence;

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

    internal sealed class EditExtraServiceCommandHandler : ICommandHandler<EditExtraServiceCommand, Task<Result>>
    {
        private readonly BookingWriteContext _dataContext;

        public EditExtraServiceCommandHandler(BookingWriteContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<Result> ExecuteAsync(EditExtraServiceCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
