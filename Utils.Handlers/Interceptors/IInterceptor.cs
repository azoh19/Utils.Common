#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Interceptors
{
    [PublicAPI]
    public interface IInterceptor<TInput, TOutput>
    {
        [CanBeNull]
        TOutput Intercept([NotNull] IHandler<TInput, TOutput> handler, [NotNull] TInput input);
    }
}
