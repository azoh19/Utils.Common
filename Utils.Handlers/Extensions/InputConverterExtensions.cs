#region Using

using System;
using JetBrains.Annotations;
using Utils.Handlers.Common;
using Utils.Handlers.Converters;

#endregion

namespace Utils.Handlers.Extensions
{
    [PublicAPI]
    public static class InputConverterExtensions
    {
        [NotNull]
        public static IHandler<TNewInput, TOutput> Converting<TInput, TOutput, TNewInput>(
            [NotNull] this IInputConverter<TInput, TOutput, TNewInput> converter,
            [NotNull]      IHandler<TInput, TOutput>                   handler)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new InputConvertedHandler<TInput, TOutput, TNewInput>(converter, handler);
        }

        [NotNull]
        public static IHandler<TNewInput, TOutput> ConvertedBy<TInput, TOutput, TNewInput>(
            [NotNull] this IHandler<TInput, TOutput>                   handler,
            [NotNull]      IInputConverter<TInput, TOutput, TNewInput> converter)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new InputConvertedHandler<TInput, TOutput, TNewInput>(converter, handler);
        }

        [NotNull]
        public static IAsyncHandler<TNewInput, TOutput> Converting<TInput, TOutput, TNewInput>(
            [NotNull] this IInputAsyncConverter<TInput, TOutput, TNewInput> converter,
            [NotNull]      IAsyncHandler<TInput, TOutput>                   handler)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new InputConvertedAsyncHandler<TInput, TOutput, TNewInput>(converter, handler);
        }

        [NotNull]
        public static IAsyncHandler<TNewInput, TOutput> ConvertedBy<TInput, TOutput, TNewInput>(
            [NotNull] this IAsyncHandler<TInput, TOutput>                   handler,
            [NotNull]      IInputAsyncConverter<TInput, TOutput, TNewInput> converter
        )
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new InputConvertedAsyncHandler<TInput, TOutput, TNewInput>(converter, handler);
        }
    }
}
