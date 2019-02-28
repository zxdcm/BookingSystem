using System;
using System.Threading.Tasks;
using BookingSystem.ApplicationCore.Interfaces;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.WritePersistence;

namespace BookingSystem.Commands.ExtraServiceCommands
{
    public class AddExtraServiceCommandHandler : ICommandHandler<AddExtraServiceCommand, Task<Result>>
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
