#region Using

using JetBrains.Annotations;
using Utils.Handlers;

#endregion

namespace Utils.DispatchConfiguration
{
    [PublicAPI]
    public interface IDispatchConfigurator
    {
        IHandlerConfigurator<TInput, TOutput> TakeHandler<THandler, TInput, TOutput>()
            where THandler : IHandler<TInput, TOutput>;

        IAsyncHandlerConfigurator<TInput, TOutput> TakeAsyncHandler<THandler, TInput, TOutput>()
            where THandler : IAsyncHandler<TInput, TOutput>;
    }
}
