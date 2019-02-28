namespace BookingSystem.ApplicationCore.Interfaces
{
    public interface ICommandDispatcher
    {
        T Dispatch<T>(ICommand<T> command);
    }
}
