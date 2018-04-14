#region Using

using System.Threading.Tasks;
using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Interceptors
{
    [PublicAPI]
    public interface IAsyncInterceptor<in THandler, in TInput, TOutput> where THandler : IAsyncHandler<TInput, TOutput>
    {
        [NotNull]
        [ItemCanBeNull]
        Task<TOutput> InterceptAsync([NotNull] THandler handler, [NotNull] TInput input);
    }
}
