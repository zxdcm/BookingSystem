namespace BookingSystem.Common.Interfaces
{
    public interface ICommandHandler<in TCommand, out TResult>
        where TCommand : ICommand<TResult>
    {
        TResult ExecuteAsync(TCommand command);
    }
}
