namespace BookingSystem.ApplicationCore.Interfaces
{
    public interface IQueryDispatcher
    {
        T Dispatch<T>(IQuery<T> query);
    }
}
