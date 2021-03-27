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
        public static IHandler<TNewInput, TOutput> Converting<TInput, TOutput, TNewInput>(
            this IInputConverter<TInput, TOutput, TNewInput> converter,
            IHandler<TInput, TOutput> handler)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new InputConvertedHandler<TInput, TOutput, TNewInput>(converter, handler);
        }


        public static IHandler<TNewInput, TOutput> ConvertedBy<TInput, TOutput, TNewInput>(
            this IHandler<TInput, TOutput> handler,
            IInputConverter<TInput, TOutput, TNewInput> converter)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new InputConvertedHandler<TInput, TOutput, TNewInput>(converter, handler);
        }


        public static IAsyncHandler<TNewInput, TOutput> Converting<TInput, TOutput, TNewInput>(
            this IInputAsyncConverter<TInput, TOutput, TNewInput> converter,
            IAsyncHandler<TInput, TOutput> handler)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new InputConvertedAsyncHandler<TInput, TOutput, TNewInput>(converter, handler);
        }


        public static IAsyncHandler<TNewInput, TOutput> ConvertedBy<TInput, TOutput, TNewInput>(
            this IAsyncHandler<TInput, TOutput> handler,
            IInputAsyncConverter<TInput, TOutput, TNewInput> converter
        )
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new InputConvertedAsyncHandler<TInput, TOutput, TNewInput>(converter, handler);
        }
    }
}
