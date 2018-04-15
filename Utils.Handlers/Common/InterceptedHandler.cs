#region Using

using System;
using JetBrains.Annotations;
using Utils.Handlers.Interceptors;

#endregion

namespace Utils.Handlers.Common
{
    [PublicAPI]
    public sealed class InterceptedHandler<TInput, TOutput> : IHandler<TInput, TOutput>
    {
        private readonly IHandler<TInput, TOutput>     _innerHandler;
        private readonly IInterceptor<TInput, TOutput> _innerInterceptor;

        public InterceptedHandler([NotNull] IInterceptor<TInput, TOutput> innerInterceptor,
                                  [NotNull] IHandler<TInput, TOutput>     innerHandler)
        {
            _innerInterceptor = innerInterceptor ?? throw new ArgumentNullException(nameof(innerInterceptor));
            _innerHandler     = innerHandler     ?? throw new ArgumentNullException(nameof(innerHandler));
        }

        #region IHandler<TInput,TOutput> Members

        public TOutput Run(TInput input) => _innerInterceptor.Intercept(_innerHandler, input);

        #endregion
    }
}
