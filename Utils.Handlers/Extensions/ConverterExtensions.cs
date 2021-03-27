#region Using

using System;
using JetBrains.Annotations;
using Utils.Handlers.Common;
using Utils.Handlers.Converters;

#endregion

namespace Utils.Handlers.Extensions
{
    [PublicAPI]
    public static class ConverterExtensions
    {
        public static IHandler<TNewInput, TNewOutput> Converting<TInput, TOutput, TNewInput, TNewOutput>(
            this IFullConverter<TInput, TOutput, TNewInput, TNewOutput> fullConverter,
            IHandler<TInput, TOutput> handler)
        {
            fullConverter = fullConverter ?? throw new ArgumentNullException(nameof(fullConverter));
            handler       = handler       ?? throw new ArgumentNullException(nameof(handler));

            return new FullConvertedHandler<TInput, TOutput, TNewInput, TNewOutput>(fullConverter, handler);
        }


        public static IHandler<TNewInput, TNewOutput> ConvertedBy<TInput, TOutput, TNewInput, TNewOutput>(
            this IHandler<TInput, TOutput> handler,
            IFullConverter<TInput, TOutput, TNewInput, TNewOutput> fullConverter)
        {
            fullConverter = fullConverter ?? throw new ArgumentNullException(nameof(fullConverter));
            handler       = handler       ?? throw new ArgumentNullException(nameof(handler));

            return new FullConvertedHandler<TInput, TOutput, TNewInput, TNewOutput>(fullConverter, handler);
        }


        public static IAsyncHandler<TNewInput, TNewOutput> Converting<TInput, TOutput, TNewInput, TNewOutput>(
            this IFullAsyncConverter<TInput, TOutput, TNewInput, TNewOutput> converter,
            IAsyncHandler<TInput, TOutput> handler)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new FullConvertedAsyncHandler<TInput, TOutput, TNewInput, TNewOutput>(converter, handler);
        }


        public static IAsyncHandler<TNewInput, TNewOutput> ConvertedBy<TInput, TOutput, TNewInput, TNewOutput>(
            this IAsyncHandler<TInput, TOutput> handler,
            IFullAsyncConverter<TInput, TOutput, TNewInput, TNewOutput> converter
        )
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new FullConvertedAsyncHandler<TInput, TOutput, TNewInput, TNewOutput>(converter, handler);
        }
    }
}
