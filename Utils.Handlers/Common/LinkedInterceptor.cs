#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Utils.Handlers.Extensions;
using Utils.Handlers.Interceptors;

#endregion

namespace Utils.Handlers.Common
{
    [PublicAPI]
    public sealed class LinkedInterceptor<TInput, TOutput> : IInterceptor<TInput, TOutput>
    {
        private readonly IEnumerable<IInterceptor<TInput, TOutput>> _interceptors;

        public LinkedInterceptor([NotNull] IInterceptor<TInput, TOutput> first, [NotNull] IInterceptor<TInput, TOutput> second)
        {
            _interceptors = new[] { first ?? throw new ArgumentNullException(nameof(first)), second ?? throw new ArgumentNullException(nameof(second)) };
        }

        public LinkedInterceptor([NotNull] [ItemNotNull] IEnumerable<IInterceptor<TInput, TOutput>> interceptors)
        {
            _interceptors = interceptors ?? throw new ArgumentNullException(nameof(interceptors));
        }

        #region IInterceptor<TInput,TOutput> Members

        public TOutput Intercept(IHandler<TInput, TOutput> handler, TInput input)
            => _interceptors.Aggregate(handler, (h, i) => h.InterceptedBy(i), h => h.Run(input));

        #endregion
    }
}
