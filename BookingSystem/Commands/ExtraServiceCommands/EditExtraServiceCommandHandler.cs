using System;
using System.Threading.Tasks;
using BookingSystem.ApplicationCore.Interfaces;
using BookingSystem.Commands.Infrastructure;
using BookingSystem.WritePersistence;

namespace BookingSystem.Commands.ExtraServiceCommands
{
    public class EditExtraServiceCommandHandler : ICommandHandler<EditExtraServiceCommand, Task<Result>>
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
