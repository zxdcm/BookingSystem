using System.Threading.Tasks;
using BookingSystem.Commands.DTOs.ExtraServiceDTOs;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Common.Interfaces;
using BookingSystem.WritePersistence;

namespace BookingSystem.Commands.ExtraServiceCommands
{
    public class AddExtraServiceCommand : ICommand<Task<Result>>
    {
        public NewExtraServiceDto ExtraService { get; }

        public AddExtraServiceCommand(NewExtraServiceDto extraService)
        {
            ExtraService = extraService;
        }

        internal sealed class AddExtraServiceCommandHandler : ICommandHandler<AddExtraServiceCommand, Task<Result>>
        {
            private readonly BookingWriteContext _dataContext;

            public AddExtraServiceCommandHandler(BookingWriteContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Result> ExecuteAsync(AddExtraServiceCommand command)
            {
                return Result.Ok();
            }
        }
    }
}
