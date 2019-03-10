using System.Threading.Tasks;

namespace BookingSystem.Common.Interfaces
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> ExecuteAsync(TQuery query);
    }

}
