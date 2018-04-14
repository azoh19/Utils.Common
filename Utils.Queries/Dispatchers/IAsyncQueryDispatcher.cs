#region Using

using System.Threading.Tasks;

#endregion

namespace Utils.Queries
{
    [PublicAPI]
    public interface IAsyncQueryDispatcher
    {
        Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}
