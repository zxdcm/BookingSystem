namespace BookingSystem.Common.Interfaces
{
    public interface IQueryDispatcher
    {
        T Dispatch<T>(IQuery<T> query);
    }
}
