using System.Threading.Tasks;

namespace BookingSystem.Common.Interfaces
{
    public interface ICommandDispatcher
    {
        Task<T> DispatchAsync<T>(ICommand<T> command);
    }
}
