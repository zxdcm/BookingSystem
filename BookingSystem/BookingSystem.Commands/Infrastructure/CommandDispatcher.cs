using System;
using BookingSystem.Common.Interfaces;

namespace BookingSystem.Commands.Infrastructure
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _provider;

        public CommandDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public T Dispatch<T>(ICommand<T> command)
        {
            Type type = typeof(ICommandHandler<,>);
            Type[] typeArgs = { command.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            T result = handler.Handle((dynamic)command);

            return result;
        }
    }
}
