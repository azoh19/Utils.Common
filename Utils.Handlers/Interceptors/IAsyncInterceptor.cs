#region Using

using System.Threading.Tasks;
using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Interceptors
{
    [PublicAPI]
    public interface IAsyncInterceptor<TInput, TOutput>
    {
        [NotNull]
        [ItemCanBeNull]
        Task<TOutput> InterceptAsync([NotNull] IAsyncHandler<TInput, TOutput> handler, [NotNull] TInput input);
    }
}
