#region Using

using System;
using JetBrains.Annotations;
using Utils.DispatchConfiguration.Configurators;
using Utils.Handlers;

#endregion

namespace Utils.DispatchConfiguration.Infrastructure
{
    [PublicAPI]
    public abstract class AsyncRootConfigurator : IAsyncRootConfigurator
    {
        protected AsyncRootConfigurator([NotNull] Action<IAsyncRootConfigurator> configure)
        {
            configure = configure ?? throw new ArgumentNullException(nameof(configure));

            configure(this);
        }

        #region IRootAsyncConfigurator<TRegistrationOptions> Members

        public IAsyncHandlerConfigurator<TInput, TOutput> TakeHandler<THandler, TInput, TOutput>()
            where THandler : IAsyncHandler<TInput, TOutput>
            => new AsyncHandlerConfigurator<TInput, TOutput>(resolver => resolver.Resolve<THandler>());

        #endregion
    }
}
