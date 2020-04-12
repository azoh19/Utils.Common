#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Utils.Handlers.Extensions;
using Utils.Handlers.Interceptors;

#endregion

namespace Utils.Handlers.Common
{
    [PublicAPI]
    public sealed class LinkedAsyncInterceptor<TInput, TOutput> : IAsyncInterceptor<TInput, TOutput>
    {
        private readonly IEnumerable<IAsyncInterceptor<TInput, TOutput>> _interceptors;

        public LinkedAsyncInterceptor([NotNull] IAsyncInterceptor<TInput, TOutput> first, [NotNull] IAsyncInterceptor<TInput, TOutput> second)
        {
            _interceptors = new[] { first ?? throw new ArgumentNullException(nameof(first)), second ?? throw new ArgumentNullException(nameof(second)) };
        }

        public LinkedAsyncInterceptor([NotNull] [ItemNotNull] IEnumerable<IAsyncInterceptor<TInput, TOutput>> interceptors)
        {
            _interceptors = interceptors ?? throw new ArgumentNullException(nameof(interceptors));
        }

        #region IAsyncInterceptor<TInput,TOutput> Members

        public Task<TOutput> InterceptAsync(IAsyncHandler<TInput, TOutput> handler, TInput input)
            => _interceptors.Aggregate(handler, (h, i) => h.InterceptedBy(i), h => h.HandleAsync(input));

        #endregion
    }
}
