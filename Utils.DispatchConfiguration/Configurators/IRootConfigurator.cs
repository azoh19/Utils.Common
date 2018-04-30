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
        IHandlerConfigurator<TInput, TOutput> TakeHandler<THandler, TInput, TOutput>()
            where THandler : IHandler<TInput, TOutput>;
    }
}
