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
        public static IHandler<TInput, TNewOutput> Converting<TInput, TOutput, TNewOutput>(
            this IOutputConverter<TInput, TOutput, TNewOutput> converter,
            IHandler<TInput, TOutput> handler)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new OutputConvertedHandler<TInput, TOutput, TNewOutput>(converter, handler);
        }


        public static IHandler<TInput, TNewOutput> ConvertedBy<TInput, TOutput, TNewOutput>(
            this IHandler<TInput, TOutput> handler,
            IOutputConverter<TInput, TOutput, TNewOutput> converter)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new OutputConvertedHandler<TInput, TOutput, TNewOutput>(converter, handler);
        }


        public static IAsyncHandler<TInput, TNewOutput> Converting<TInput, TOutput, TNewOutput>(
            this IOutputAsyncConverter<TInput, TOutput, TNewOutput> converter,
            IAsyncHandler<TInput, TOutput> handler)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new OutputConvertedAsyncHandler<TInput, TOutput, TNewOutput>(converter, handler);
        }


        public static IAsyncHandler<TInput, TNewOutput> ConvertedBy<TInput, TOutput, TNewOutput>(
            this IAsyncHandler<TInput, TOutput> handler,
            IOutputAsyncConverter<TInput, TOutput, TNewOutput> converter
        )
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new OutputConvertedAsyncHandler<TInput, TOutput, TNewOutput>(converter, handler);
        }
    }
}
