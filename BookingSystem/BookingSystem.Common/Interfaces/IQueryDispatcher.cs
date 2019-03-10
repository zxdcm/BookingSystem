using System.Threading.Tasks;

namespace BookingSystem.Common.Interfaces
{
    public interface IQueryDispatcher
    {
        Task<T> DispatchAsync<T>(IQuery<T> query);
    }
}
