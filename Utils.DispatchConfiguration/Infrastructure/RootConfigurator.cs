#region Using

using System;
using JetBrains.Annotations;
using Utils.DispatchConfiguration.Configurators;

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

        IHandlerConfigurator<TInput, TOutput> IRootConfigurator.Take<THandler, TInput, TOutput>()
            => new HandlerConfigurator<TInput, TOutput>(resolver => resolver.Resolve<THandler>());

        IAsyncHandlerConfigurator<TInput, TOutput> IRootConfigurator.TakeAsync<THandler, TInput, TOutput>()
            => new AsyncHandlerConfigurator<TInput, TOutput>(resolver => resolver.Resolve<THandler>());

        #endregion
    }
}
