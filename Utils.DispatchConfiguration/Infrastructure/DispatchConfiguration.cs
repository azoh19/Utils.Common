#region Using

using System;
using JetBrains.Annotations;
using Utils.DispatchConfiguration.Configurators;
using Utils.Handlers;

#endregion

namespace Utils.DispatchConfiguration.Infrastructure
{
    [PublicAPI]
    public abstract class DispatchConfiguration<TContainerOptions> : IRootConfigurator<TContainerOptions>
    {
        [NotNull]
        private readonly IContainerBridge<TContainerOptions> _bridge;

        protected DispatchConfiguration([NotNull] IContainerBridge<TContainerOptions> bridge, [NotNull] Action<IRootConfigurator<TContainerOptions>> configure)
        {
            _bridge   = bridge    ?? throw new ArgumentNullException(nameof(bridge));
            configure = configure ?? throw new ArgumentNullException(nameof(configure));

            configure(this);
        }

        #region IRootConfigurator<TContainerOptions> Members

        public IHandlerConfigurator<TContainerOptions, TInput, TOutput> TakeHandler<THandler, TInput, TOutput>() where THandler : IHandler<TInput, TOutput>
            => new HandlerConfigurator<TContainerOptions, TInput, TOutput>(_bridge, resolver => resolver.Resolve<THandler>());

        #endregion
    }
}
