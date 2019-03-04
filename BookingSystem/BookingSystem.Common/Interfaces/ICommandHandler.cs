using System.Threading.Tasks;

namespace BookingSystem.Common.Interfaces
{
    public interface ICommandHandler<in TCommand, out TResult>
        where TCommand : ICommand<TResult>
    {
        TResult Execute(TCommand command);
    }
    public interface IAsyncCommandHandler<in TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        Task<TResult> ExecuteAsync(TCommand command);
    }
}
