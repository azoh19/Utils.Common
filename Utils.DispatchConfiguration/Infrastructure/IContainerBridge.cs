#region Using

using System;
using JetBrains.Annotations;
using Utils.AbstractDI;
using Utils.Handlers;

#endregion

namespace Utils.DispatchConfiguration.Infrastructure
{
    [PublicAPI]
    public interface IContainerBridge<out TContainerOptions>
    {
        [NotNull]
        TContainerOptions Register<TInput, TOutput>([NotNull] Func<IResolver, IHandler<TInput, TOutput>> construct);

        [NotNull]
        TContainerOptions Register<TInput, TOutput>([NotNull] Func<IResolver, IAsyncHandler<TInput, TOutput>> construct);
    }
}
