#region Using

using System.Threading.Tasks;
using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Interceptors
{
    [PublicAPI]
    public interface IAsyncInterceptor<TInput, TOutput>
    {
        [ItemCanBeNull]
        Task<TOutput> InterceptAsync(IAsyncHandler<TInput, TOutput> handler, TInput input);
    }
}
