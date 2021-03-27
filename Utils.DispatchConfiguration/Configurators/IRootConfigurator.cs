#region Using

using JetBrains.Annotations;
using Utils.Handlers;

#endregion

namespace Utils.DispatchConfiguration.Configurators
{
    [PublicAPI]
    public interface IRootConfigurator
    {
        IHandlerConfigurator<TInput, TOutput> Take<THandler, TInput, TOutput>()
            where THandler : class, IHandler<TInput, TOutput>;

        IAsyncHandlerConfigurator<TInput, TOutput> TakeAsync<THandler, TInput, TOutput>()
            where THandler : class, IAsyncHandler<TInput, TOutput>;
    }
}
