using System;
using System.Threading.Tasks;
using BookingSystem.Commands.Infrastructure.Validators;
using BookingSystem.Common.Interfaces;

namespace BookingSystem.Commands.Infrastructure.Decorators
{
    public sealed class ValidationDecorator<TCommand, TResult> : 
        ICommandHandler<TCommand, TResult>, 
        IAsyncCommandHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        private readonly ICommandHandler<TCommand, TResult> _handler;
        private readonly IAsyncCommandHandler<TCommand, TResult> _asyncHandler;
        private readonly IValidator<TCommand> _validator;

        public ValidationDecorator(ICommandHandler<TCommand, TResult> handler, IValidator<TCommand> validator)
        {
            _handler = handler;
            _validator = validator;
        }

        public ValidationDecorator(IAsyncCommandHandler<TCommand, TResult> handler, IValidator<TCommand> validator)
        {
            _asyncHandler = handler;
            _validator = validator;
        }

        public TResult Execute(TCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> ExecuteAsync(TCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
