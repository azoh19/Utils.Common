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
        public static IHandler<TInput, TOutput> Intercepting<TInput, TOutput>(this IInterceptor<TInput, TOutput> interceptor,
                                                                              IHandler<TInput, TOutput> handler)
        {
            interceptor = interceptor ?? throw new ArgumentNullException(nameof(interceptor));
            handler     = handler     ?? throw new ArgumentNullException(nameof(handler));

            return new InterceptedHandler<TInput, TOutput>(interceptor, handler);
        }


        public static IHandler<TInput, TOutput> InterceptedBy<TInput, TOutput>(this IHandler<TInput, TOutput> handler,
                                                                               IInterceptor<TInput, TOutput> interceptor)
        {
            interceptor = interceptor ?? throw new ArgumentNullException(nameof(interceptor));
            handler     = handler     ?? throw new ArgumentNullException(nameof(handler));

            return new InterceptedHandler<TInput, TOutput>(interceptor, handler);
        }


        public static IAsyncHandler<TInput, TOutput> Intercepting<TInput, TOutput>(
            this IAsyncInterceptor<TInput, TOutput> interceptor,
            IAsyncHandler<TInput, TOutput> handler)
        {
            interceptor = interceptor ?? throw new ArgumentNullException(nameof(interceptor));
            handler     = handler     ?? throw new ArgumentNullException(nameof(handler));

            return new InterceptedAsyncHandler<TInput, TOutput>(interceptor, handler);
        }


        public static IAsyncHandler<TInput, TOutput> InterceptedBy<TInput, TOutput>(this IAsyncHandler<TInput, TOutput> handler,
                                                                                    IAsyncInterceptor<TInput, TOutput> interceptor
        )
        {
            interceptor = interceptor ?? throw new ArgumentNullException(nameof(interceptor));
            handler     = handler     ?? throw new ArgumentNullException(nameof(handler));

            return new InterceptedAsyncHandler<TInput, TOutput>(interceptor, handler);
        }


        public static IInterceptor<TInput, TOutput> Link<TInput, TOutput>(this IInterceptor<TInput, TOutput> first,
                                                                          IInterceptor<TInput, TOutput> second)
        {
            first  = first  ?? throw new ArgumentNullException(nameof(first));
            second = second ?? throw new ArgumentNullException(nameof(second));

            return new LinkedInterceptor<TInput, TOutput>(first, second);
        }
    }
}
