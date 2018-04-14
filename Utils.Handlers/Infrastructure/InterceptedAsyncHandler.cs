#region Using

using System.Threading.Tasks;
using JetBrains.Annotations;
using Utils.Handlers.Interceptors;

#endregion

namespace Utils.Handlers.Infrastructure
{
    internal sealed class InterceptedAsyncHandler<TInterceptor, THandler, TInput, TOutput> : IAsyncHandler<TInput, TOutput>
        where TInterceptor : IAsyncInterceptor<THandler, TInput, TOutput>
        where THandler : IAsyncHandler<TInput, TOutput>
    {
        private readonly THandler     _innerHandler;
        private readonly TInterceptor _innerInterceptor;

        public InterceptedAsyncHandler([NotNull] TInterceptor innerInterceptor, [NotNull] THandler innerHandler)
        {
            _innerInterceptor = innerInterceptor;
            _innerHandler     = innerHandler;
        }

        #region IAsyncHandler<TInput,TOutput> Members

        public Task<TOutput> RunAsync(TInput input) => _innerInterceptor.InterceptAsync(_innerHandler, input);

        #endregion
    }
}
