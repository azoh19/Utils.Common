#region Using

using JetBrains.Annotations;
using Utils.DispatchConfiguration.Configurators;

#endregion

namespace Utils.DispatchConfiguration.Infrastructure
{
    [PublicAPI]
    public sealed class RootConfigurator : IRootConfigurator
    {
        IHandlerConfigurator<TInput, TOutput> IRootConfigurator.Take<THandler, TInput, TOutput>()
            => new HandlerConfigurator<TInput, TOutput>(resolver => resolver.Resolve<THandler>());

        IAsyncHandlerConfigurator<TInput, TOutput> IRootConfigurator.TakeAsync<THandler, TInput, TOutput>()
            => new AsyncHandlerConfigurator<TInput, TOutput>(resolver => resolver.Resolve<THandler>());
    }
}
