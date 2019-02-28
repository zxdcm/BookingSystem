namespace BookingSystem.Common.Interfaces
{
    public interface ICommandDispatcher
    {
        T Dispatch<T>(ICommand<T> command);
    }
}
