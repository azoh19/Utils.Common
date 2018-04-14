#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Interceptors
{
    [PublicAPI]
    public interface IInterceptor<in THandler, in TInput, out TOutput> where THandler : IHandler<TInput, TOutput>
    {
        [CanBeNull]
        TOutput Intercept([NotNull] THandler handler, [NotNull] TInput input);
    }
}
