#region Using

using System;
using JetBrains.Annotations;
using Utils.Handlers.Common;
using Utils.Handlers.Interceptors;

#endregion

namespace Utils.Handlers.Extensions
{
    [PublicAPI]
    public static class InterceptorExtensions
    {
        [NotNull]
        public static IHandler<TInput, TOutput> Intercepting<TInput, TOutput>([NotNull] this IInterceptor<TInput, TOutput> interceptor,
                                                                              [NotNull]      IHandler<TInput, TOutput>     handler)
        {
            interceptor = interceptor ?? throw new ArgumentNullException(nameof(interceptor));
            handler     = handler     ?? throw new ArgumentNullException(nameof(handler));

            return new InterceptedHandler<TInput, TOutput>(interceptor, handler);
        }

        [NotNull]
        public static IHandler<TInput, TOutput> InterceptedBy<TInput, TOutput>([NotNull] this IHandler<TInput, TOutput>     handler,
                                                                               [NotNull]      IInterceptor<TInput, TOutput> interceptor)
        {
            interceptor = interceptor ?? throw new ArgumentNullException(nameof(interceptor));
            handler     = handler     ?? throw new ArgumentNullException(nameof(handler));

            return new InterceptedHandler<TInput, TOutput>(interceptor, handler);
        }

        [NotNull]
        public static IAsyncHandler<TInput, TOutput> Intercepting<TInput, TOutput>([NotNull] this IAsyncInterceptor<TInput, TOutput> interceptor,
                                                                                   [NotNull]      IAsyncHandler<TInput, TOutput>     handler)
        {
            interceptor = interceptor ?? throw new ArgumentNullException(nameof(interceptor));
            handler     = handler     ?? throw new ArgumentNullException(nameof(handler));

            return new InterceptedAsyncHandler<TInput, TOutput>(interceptor, handler);
        }

        [NotNull]
        public static IAsyncHandler<TInput, TOutput> InterceptedBy<TInput, TOutput>([NotNull] this IAsyncHandler<TInput, TOutput>     handler,
                                                                                    [NotNull]      IAsyncInterceptor<TInput, TOutput> interceptor
        )
        {
            interceptor = interceptor ?? throw new ArgumentNullException(nameof(interceptor));
            handler     = handler     ?? throw new ArgumentNullException(nameof(handler));

            return new InterceptedAsyncHandler<TInput, TOutput>(interceptor, handler);
        }

        [NotNull]
        public static IInterceptor<TInput, TOutput> Link<TInput, TOutput>([NotNull] this IInterceptor<TInput, TOutput> first,
                                                                          [NotNull]      IInterceptor<TInput, TOutput> second)
        {
            first  = first  ?? throw new ArgumentNullException(nameof(first));
            second = second ?? throw new ArgumentNullException(nameof(second));

            return new LinkedInterceptor<TInput, TOutput>(first, second);
        }
    }
}
