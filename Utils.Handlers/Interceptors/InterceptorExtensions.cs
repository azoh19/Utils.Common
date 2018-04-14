#region Using

using System;
using JetBrains.Annotations;
using Utils.Handlers.Infrastructure;

#endregion

namespace Utils.Handlers.Interceptors
{
    [PublicAPI]
    public static class InterceptorExtensions
    {
        [NotNull]
        public static IHandler<TInput, TOutput> Intercepting<TInput, TOutput>([NotNull] this IInterceptor<IHandler<TInput, TOutput>, TInput, TOutput> interceptor,
                                                                              [NotNull]      IHandler<TInput, TOutput>                                handler)
        {
            interceptor = interceptor ?? throw new ArgumentNullException(nameof(interceptor));
            handler     = handler     ?? throw new ArgumentNullException(nameof(handler));

            return new InterceptedHandler<IInterceptor<IHandler<TInput, TOutput>, TInput, TOutput>, IHandler<TInput, TOutput>, TInput, TOutput>(interceptor, handler);
        }

        [NotNull]
        public static IHandler<TInput, TOutput> InterceptedBy<TInput, TOutput>([NotNull] this IHandler<TInput, TOutput>                                handler,
                                                                               [NotNull]      IInterceptor<IHandler<TInput, TOutput>, TInput, TOutput> interceptor)
        {
            interceptor = interceptor ?? throw new ArgumentNullException(nameof(interceptor));
            handler     = handler     ?? throw new ArgumentNullException(nameof(handler));

            return new InterceptedHandler<IInterceptor<IHandler<TInput, TOutput>, TInput, TOutput>, IHandler<TInput, TOutput>, TInput, TOutput>(interceptor, handler);
        }

        [NotNull]
        public static IAsyncHandler<TInput, TOutput> InterceptingAsync<TInput, TOutput>([NotNull] this IAsyncInterceptor<IAsyncHandler<TInput, TOutput>, TInput, TOutput> interceptor,
                                                                                        [NotNull]      IAsyncHandler<TInput, TOutput>                                     handler)
        {
            interceptor = interceptor ?? throw new ArgumentNullException(nameof(interceptor));
            handler     = handler     ?? throw new ArgumentNullException(nameof(handler));

            return new InterceptedAsyncHandler<IAsyncInterceptor<IAsyncHandler<TInput, TOutput>, TInput, TOutput>, IAsyncHandler<TInput, TOutput>, TInput, TOutput>(interceptor, handler);
        }

        [NotNull]
        public static IAsyncHandler<TInput, TOutput> InterceptedByAsync<TInput, TOutput>([NotNull] this IAsyncHandler<TInput, TOutput>                                     handler,
                                                                                         [NotNull]      IAsyncInterceptor<IAsyncHandler<TInput, TOutput>, TInput, TOutput> interceptor
        )
        {
            interceptor = interceptor ?? throw new ArgumentNullException(nameof(interceptor));
            handler     = handler     ?? throw new ArgumentNullException(nameof(handler));

            return new InterceptedAsyncHandler<IAsyncInterceptor<IAsyncHandler<TInput, TOutput>, TInput, TOutput>, IAsyncHandler<TInput, TOutput>, TInput, TOutput>(interceptor, handler);
        }
    }
}
