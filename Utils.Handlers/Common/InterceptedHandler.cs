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
        private readonly IHandler<TInput, TOutput> _innerHandler;
        private readonly IInterceptor<TInput, TOutput> _innerInterceptor;

        public InterceptedHandler(IInterceptor<TInput, TOutput> innerInterceptor,
                                  IHandler<TInput, TOutput> innerHandler)
        {
            _innerInterceptor = innerInterceptor ?? throw new ArgumentNullException(nameof(innerInterceptor));
            _innerHandler     = innerHandler     ?? throw new ArgumentNullException(nameof(innerHandler));
        }

        public TOutput Handle(TInput input)
            => _innerInterceptor.Intercept(_innerHandler, input);
    }
}
