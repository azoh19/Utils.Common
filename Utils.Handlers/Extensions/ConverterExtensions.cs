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
        [NotNull]
        public static IHandler<TNewInput, TNewOutput> Converting<TInput, TOutput, TNewInput, TNewOutput>(
            [NotNull] this IFullConverter<TInput, TOutput, TNewInput, TNewOutput> fullConverter,
            [NotNull]      IHandler<TInput, TOutput>                              handler)
        {
            fullConverter = fullConverter ?? throw new ArgumentNullException(nameof(fullConverter));
            handler       = handler       ?? throw new ArgumentNullException(nameof(handler));

            return new FullConvertedHandler<TInput, TOutput, TNewInput, TNewOutput>(fullConverter, handler);
        }

        [NotNull]
        public static IHandler<TNewInput, TNewOutput> ConvertedBy<TInput, TOutput, TNewInput, TNewOutput>(
            [NotNull] this IHandler<TInput, TOutput>                              handler,
            [NotNull]      IFullConverter<TInput, TOutput, TNewInput, TNewOutput> fullConverter)
        {
            fullConverter = fullConverter ?? throw new ArgumentNullException(nameof(fullConverter));
            handler       = handler       ?? throw new ArgumentNullException(nameof(handler));

            return new FullConvertedHandler<TInput, TOutput, TNewInput, TNewOutput>(fullConverter, handler);
        }

        [NotNull]
        public static IAsyncHandler<TNewInput, TNewOutput> Converting<TInput, TOutput, TNewInput, TNewOutput>(
            [NotNull] this IFullAsyncConverter<TInput, TOutput, TNewInput, TNewOutput> converter,
            [NotNull]      IAsyncHandler<TInput, TOutput>                              handler)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new FullConvertedAsyncHandler<TInput, TOutput, TNewInput, TNewOutput>(converter, handler);
        }

        [NotNull]
        public static IAsyncHandler<TNewInput, TNewOutput> ConvertedBy<TInput, TOutput, TNewInput, TNewOutput>(
            [NotNull] this IAsyncHandler<TInput, TOutput>                              handler,
            [NotNull]      IFullAsyncConverter<TInput, TOutput, TNewInput, TNewOutput> converter
        )
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new FullConvertedAsyncHandler<TInput, TOutput, TNewInput, TNewOutput>(converter, handler);
        }
    }
}
