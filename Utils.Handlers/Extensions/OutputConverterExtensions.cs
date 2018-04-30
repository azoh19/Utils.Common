#region Using

using System;
using JetBrains.Annotations;
using Utils.Handlers.Common;
using Utils.Handlers.Converters;

#endregion

namespace Utils.Handlers.Extensions
{
    [PublicAPI]
    public static class OutputConverterExtensions
    {
        [NotNull]
        public static IHandler<TInput, TNewOutput> Converting<TInput, TOutput, TNewOutput>(
            [NotNull] this IOutputConverter<TInput, TOutput, TNewOutput> converter,
            [NotNull]      IHandler<TInput, TOutput>                     handler)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new OutputConvertedHandler<TInput, TOutput, TNewOutput>(converter, handler);
        }

        [NotNull]
        public static IHandler<TInput, TNewOutput> ConvertedBy<TInput, TOutput, TNewOutput>(
            [NotNull] this IHandler<TInput, TOutput>                     handler,
            [NotNull]      IOutputConverter<TInput, TOutput, TNewOutput> converter)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new OutputConvertedHandler<TInput, TOutput, TNewOutput>(converter, handler);
        }

        [NotNull]
        public static IAsyncHandler<TInput, TNewOutput> Converting<TInput, TOutput, TNewOutput>(
            [NotNull] this IOutputAsyncConverter<TInput, TOutput, TNewOutput> converter,
            [NotNull]      IAsyncHandler<TInput, TOutput>                     handler)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new OutputConvertedAsyncHandler<TInput, TOutput, TNewOutput>(converter, handler);
        }

        [NotNull]
        public static IAsyncHandler<TInput, TNewOutput> ConvertedBy<TInput, TOutput, TNewOutput>(
            [NotNull] this IAsyncHandler<TInput, TOutput>                     handler,
            [NotNull]      IOutputAsyncConverter<TInput, TOutput, TNewOutput> converter
        )
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new OutputConvertedAsyncHandler<TInput, TOutput, TNewOutput>(converter, handler);
        }
    }
}
