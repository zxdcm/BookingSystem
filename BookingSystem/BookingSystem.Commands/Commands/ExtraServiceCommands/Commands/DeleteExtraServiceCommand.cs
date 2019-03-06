using System.Threading.Tasks;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.Common.Interfaces;
using BookingSystem.WritePersistence;
using BookingSystem.WritePersistence.WriteModels;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Commands.Commands.ExtraServiceCommands.Commands
{
    public class DeleteExtraService : ICommand<Task<Result>>
    {
        public int ExtraServiceId { get; }

        public DeleteExtraService(int extraServiceId)
        {
            ExtraServiceId = extraServiceId;
        }
    }

    public class DeleteExtraServiceHandler : ICommandHandler<DeleteExtraService, Task<Result>>
    {
        private readonly BookingWriteContext _dataContext;

        public DeleteExtraServiceHandler(BookingWriteContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result> Execute(DeleteExtraService command)
        {
            var extraService = await _dataContext.ExtraServices.FindAsync(command.ExtraServiceId);
            if (extraService == null)
                return Result.NullEntityError(nameof(Hotel), command.ExtraServiceId);
            extraService.IsAvailable = false;
            await _dataContext.SaveChangesAsync();
            return Result.Ok();
        }
    }
}
