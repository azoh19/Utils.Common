#region Using

using System;
using JetBrains.Annotations;
using Utils.DispatchConfiguration.Configurators;
using Utils.Handlers;

#endregion

namespace Utils.DispatchConfiguration.Infrastructure
{
    [PublicAPI]
    public abstract class AsyncDispatchConfiguration<TContainerOptions> : IRootAsyncConfigurator<TContainerOptions>
    {
        [NotNull]
        private readonly IContainerBridge<TContainerOptions> _bridge;

        protected AsyncDispatchConfiguration([NotNull] IContainerBridge<TContainerOptions>               bridge,
                                             [NotNull] Action<IRootAsyncConfigurator<TContainerOptions>> configure)
        {
            _bridge   = bridge    ?? throw new ArgumentNullException(nameof(bridge));
            configure = configure ?? throw new ArgumentNullException(nameof(configure));

            configure(this);
        }

        #region IRootAsyncConfigurator<TContainerOptions> Members

        public IAsyncHandlerConfigurator<TContainerOptions, TInput, TOutput> TakeAsyncHandler<THandler, TInput, TOutput>()
            where THandler : IAsyncHandler<TInput, TOutput>
            => new AsyncHandlerConfigurator<TContainerOptions, TInput, TOutput>(_bridge, resolver => resolver.Resolve<THandler>());

        #endregion
    }
}
