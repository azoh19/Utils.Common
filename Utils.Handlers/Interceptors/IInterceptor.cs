#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Interceptors
{
    [PublicAPI]
    public interface IInterceptor<TInput, TOutput>
    {
        [CanBeNull]
        TOutput Intercept(IHandler<TInput, TOutput> handler, TInput input);
    }
}
