#region Using

using JetBrains.Annotations;
using Utils.Handlers;

#endregion

namespace Utils.DispatchConfiguration.Configurators
{
    [PublicAPI]
    public interface IAsyncRootConfigurator
    {
        [NotNull]
        IAsyncHandlerConfigurator<TInput, TOutput> TakeHandler<THandler, TInput, TOutput>()
            where THandler : IAsyncHandler<TInput, TOutput>;
    }
}
