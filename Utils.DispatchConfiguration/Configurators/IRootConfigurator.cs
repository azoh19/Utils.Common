#region Using

using JetBrains.Annotations;
using Utils.Handlers;

#endregion

namespace Utils.DispatchConfiguration.Configurators
{
    [PublicAPI]
    public interface IRootConfigurator<TContainerOptions>
    {
        [NotNull]
        IHandlerConfigurator<TContainerOptions, TInput, TOutput> TakeHandler<THandler, TInput, TOutput>()
            where THandler : IHandler<TInput, TOutput>;
    }

    [PublicAPI]
    public interface IRootAsyncConfigurator<TContainerOptions>
    {
        [NotNull]
        IAsyncHandlerConfigurator<TContainerOptions, TInput, TOutput> TakeAsyncHandler<THandler, TInput, TOutput>()
            where THandler : IAsyncHandler<TInput, TOutput>;
    }
}
