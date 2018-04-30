#region Using

using System;
using JetBrains.Annotations;
using Utils.DispatchConfiguration.Configurators;
using Utils.Handlers;

#endregion

namespace Utils.DispatchConfiguration.Infrastructure
{
    [PublicAPI]
    public sealed class RootConfigurator : IRootConfigurator
    {
        public RootConfigurator([NotNull] Action<IRootConfigurator> configure)
        {
            configure = configure ?? throw new ArgumentNullException(nameof(configure));

            configure(this);
        }

        #region IRootConfigurator<TRegistrationOptions> Members

        public IHandlerConfigurator<TInput, TOutput> TakeHandler<THandler, TInput, TOutput>()
            where THandler : IHandler<TInput, TOutput>
            => new HandlerConfigurator<TInput, TOutput>(resolver => resolver.Resolve<THandler>());

        #endregion
    }
}
