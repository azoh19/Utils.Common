﻿#region Using

using System.Threading.Tasks;
using JetBrains.Annotations;
using Utils.Handlers.Interceptors;

#endregion

namespace Utils.Handlers.Common
{
    [PublicAPI]
    public sealed class InterceptedAsyncHandler<TInput, TOutput> : IAsyncHandler<TInput, TOutput>
    {
        private readonly IAsyncHandler<TInput, TOutput> _innerHandler;
        private readonly IAsyncInterceptor<TInput, TOutput> _innerInterceptor;

        public InterceptedAsyncHandler(IAsyncInterceptor<TInput, TOutput> innerInterceptor,
                                       IAsyncHandler<TInput, TOutput> innerHandler)
        {
            _innerInterceptor = innerInterceptor;
            _innerHandler     = innerHandler;
        }

        public Task<TOutput> HandleAsync(TInput input)
            => _innerInterceptor.InterceptAsync(_innerHandler, input);
    }
}
