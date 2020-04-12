#region Using

using JetBrains.Annotations;
using Utils.Handlers;

#endregion

namespace Utils.DispatchConfiguration.Configurators
{
    [PublicAPI]
    public interface IRootConfigurator
    {
        [NotNull]
        IHandlerConfigurator<TInput, TOutput> Take<THandler, TInput, TOutput>()
            where THandler : IHandler<TInput, TOutput>;

        [NotNull]
        IAsyncHandlerConfigurator<TInput, TOutput> TakeAsync<THandler, TInput, TOutput>()
            where THandler : IAsyncHandler<TInput, TOutput>;
    }
}
