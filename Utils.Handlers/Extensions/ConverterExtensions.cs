#region Using

using System;
using JetBrains.Annotations;
using Utils.Handlers.Converters;
using Utils.Handlers.Common;

#endregion

namespace Utils.Handlers.Extensions
{
    [PublicAPI]
    public static class ConverterExtensions
    {
        [NotNull]
        public static IHandler<TNewInput, TNewOutput> Converting<TInput, TOutput, TNewInput, TNewOutput>(
            [NotNull] this IConverter<TInput, TOutput, TNewInput, TNewOutput> converter,
            [NotNull]      IHandler<TInput, TOutput>                          handler)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new ConvertedHandler<TInput, TOutput, TNewInput, TNewOutput>(converter, handler);
        }

        [NotNull]
        public static IHandler<TNewInput, TNewOutput> ConvertedBy<TInput, TOutput, TNewInput, TNewOutput>(
            [NotNull] this IHandler<TInput, TOutput>                          handler,
            [NotNull]      IConverter<TInput, TOutput, TNewInput, TNewOutput> converter)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new ConvertedHandler<TInput, TOutput, TNewInput, TNewOutput>(converter, handler);
        }

        [NotNull]
        public static IAsyncHandler<TNewInput, TNewOutput> Converting<TInput, TOutput, TNewInput, TNewOutput>(
            [NotNull] this IAsyncConverter<TInput, TOutput, TNewInput, TNewOutput> converter,
            [NotNull]      IAsyncHandler<TInput, TOutput>                          handler)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new ConvertedAsyncHandler<TInput, TOutput, TNewInput, TNewOutput>(converter, handler);
        }

        [NotNull]
        public static IAsyncHandler<TNewInput, TNewOutput> ConvertedBy<TInput, TOutput, TNewInput, TNewOutput>(
            [NotNull] this IAsyncHandler<TInput, TOutput>                          handler,
            [NotNull]      IAsyncConverter<TInput, TOutput, TNewInput, TNewOutput> converter
        )
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new ConvertedAsyncHandler<TInput, TOutput, TNewInput, TNewOutput>(converter, handler);
        }
    }
}
