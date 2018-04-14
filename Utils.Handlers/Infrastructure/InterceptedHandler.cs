#region Using

using System;
using JetBrains.Annotations;
using Utils.Handlers.Interceptors;

#endregion

namespace Utils.Handlers.Infrastructure
{
    internal sealed class InterceptedHandler<TInterceptor, THandler, TInput, TOutput> : IHandler<TInput, TOutput>
        where TInterceptor : class, IInterceptor<THandler, TInput, TOutput>
        where THandler : class, IHandler<TInput, TOutput>
    {
        private readonly THandler     _innerHandler;
        private readonly TInterceptor _innerInterceptor;

        public InterceptedHandler([NotNull] TInterceptor innerInterceptor, [NotNull] THandler innerHandler)
        {
            _innerInterceptor = innerInterceptor ?? throw new ArgumentNullException(nameof(innerInterceptor));
            _innerHandler     = innerHandler     ?? throw new ArgumentNullException(nameof(innerHandler));
        }

        #region IHandler<TInput,TOutput> Members

        public TOutput Run(TInput input) => _innerInterceptor.Intercept(_innerHandler, input);

        #endregion
    }
}
