#region Using

using System;
using JetBrains.Annotations;
using Utils.Handlers.Infrastructure;

#endregion

namespace Utils.Handlers.Converters
{
    [PublicAPI]
    public static class ConverterExtensions
    {
        [NotNull]
        public static IHandler<TInput, TOutput> Converting<THandlerInput, THandlerOutput, TInput, TOutput>(
            [NotNull] this IConverter<IHandler<THandlerInput, THandlerOutput>, THandlerInput, THandlerOutput, TInput, TOutput> converter,
            [NotNull]      IHandler<THandlerInput, THandlerOutput>                                                             handler)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new ConvertedHandler<IConverter<IHandler<THandlerInput, THandlerOutput>, THandlerInput, THandlerOutput, TInput, TOutput>,
                IHandler<THandlerInput, THandlerOutput>,
                THandlerInput, THandlerOutput, TInput, TOutput>(converter, handler);
        }

        [NotNull]
        public static IHandler<TInput, TOutput> ConvertedBy<THandlerInput, THandlerOutput, TInput, TOutput>(
            [NotNull] this IHandler<THandlerInput, THandlerOutput>                                                             handler,
            [NotNull]      IConverter<IHandler<THandlerInput, THandlerOutput>, THandlerInput, THandlerOutput, TInput, TOutput> converter)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new ConvertedHandler<IConverter<IHandler<THandlerInput, THandlerOutput>, THandlerInput, THandlerOutput, TInput, TOutput>,
                IHandler<THandlerInput, THandlerOutput>,
                THandlerInput, THandlerOutput, TInput, TOutput>(converter, handler);
        }

        [NotNull]
        public static IAsyncHandler<TInput, TOutput> ConvertingAsync<THandlerInput, THandlerOutput, TInput, TOutput>(
            [NotNull] this IAsyncConverter<IAsyncHandler<THandlerInput, THandlerOutput>, THandlerInput, THandlerOutput, TInput, TOutput> converter,
            [NotNull]      IAsyncHandler<THandlerInput, THandlerOutput>                                                                  handler)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new ConvertedAsyncHandler<IAsyncConverter<IAsyncHandler<THandlerInput, THandlerOutput>, THandlerInput, THandlerOutput, TInput, TOutput>,
                IAsyncHandler<THandlerInput, THandlerOutput>,
                THandlerInput, THandlerOutput, TInput, TOutput>(converter, handler);
        }

        [NotNull]
        public static IAsyncHandler<TInput, TOutput> ConvertedByAsync<THandlerInput, THandlerOutput, TInput, TOutput>(
            [NotNull] this IAsyncHandler<THandlerInput, THandlerOutput>                                                                  handler,
            [NotNull]      IAsyncConverter<IAsyncHandler<THandlerInput, THandlerOutput>, THandlerInput, THandlerOutput, TInput, TOutput> converter
        )
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new ConvertedAsyncHandler<IAsyncConverter<IAsyncHandler<THandlerInput, THandlerOutput>, THandlerInput, THandlerOutput, TInput, TOutput>,
                IAsyncHandler<THandlerInput, THandlerOutput>,
                THandlerInput, THandlerOutput, TInput, TOutput>(converter, handler);
        }

        [NotNull]
        public static IHandler<TInput, TOutput> Converting<THandlerInput, TInput, TOutput>(
            [NotNull] this IInputConverter<IHandler<THandlerInput, TOutput>, THandlerInput, TInput, TOutput> converter,
            [NotNull]      IHandler<THandlerInput, TOutput>                                                  handler)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new InputConvertedHandler<IInputConverter<IHandler<THandlerInput, TOutput>, THandlerInput, TInput, TOutput>,
                IHandler<THandlerInput, TOutput>,
                THandlerInput, TInput, TOutput>(converter, handler);
        }

        [NotNull]
        public static IHandler<TInput, TOutput> ConvertedBy<THandlerInput, TInput, TOutput>(
            [NotNull] this IHandler<THandlerInput, TOutput>                                                  handler,
            [NotNull]      IInputConverter<IHandler<THandlerInput, TOutput>, THandlerInput, TInput, TOutput> converter)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new InputConvertedHandler<IInputConverter<IHandler<THandlerInput, TOutput>, THandlerInput, TInput, TOutput>,
                IHandler<THandlerInput, TOutput>,
                THandlerInput, TInput, TOutput>(converter, handler);
        }

        [NotNull]
        public static IAsyncHandler<TInput, TOutput> ConvertingAsync<THandlerInput, TInput, TOutput>(
            [NotNull] this IInputAsyncConverter<IAsyncHandler<THandlerInput, TOutput>, THandlerInput, TInput, TOutput> converter,
            [NotNull]      IAsyncHandler<THandlerInput, TOutput>                                                       handler)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new InputConvertedAsyncHandler<IInputAsyncConverter<IAsyncHandler<THandlerInput, TOutput>, THandlerInput, TInput, TOutput>,
                IAsyncHandler<THandlerInput, TOutput>,
                THandlerInput, TInput, TOutput>(converter, handler);
        }

        [NotNull]
        public static IAsyncHandler<TInput, TOutput> ConvertedByAsync<THandlerInput, TInput, TOutput>(
            [NotNull] this IAsyncHandler<THandlerInput, TOutput>                                                       handler,
            [NotNull]      IInputAsyncConverter<IAsyncHandler<THandlerInput, TOutput>, THandlerInput, TInput, TOutput> converter
        )
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new InputConvertedAsyncHandler<IInputAsyncConverter<IAsyncHandler<THandlerInput, TOutput>, THandlerInput, TInput, TOutput>,
                IAsyncHandler<THandlerInput, TOutput>,
                THandlerInput, TInput, TOutput>(converter, handler);
        }

        [NotNull]
        public static IHandler<TInput, TOutput> Converting<THandlerOutput, TInput, TOutput>(
            [NotNull] this IOutputConverter<IHandler<TInput, THandlerOutput>, THandlerOutput, TInput, TOutput> converter,
            [NotNull]      IHandler<TInput, THandlerOutput>                                                    handler)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new OutputConvertedHandler<IOutputConverter<IHandler<TInput, THandlerOutput>, THandlerOutput, TInput, TOutput>,
                IHandler<TInput, THandlerOutput>,
                THandlerOutput, TInput, TOutput>(converter, handler);
        }

        [NotNull]
        public static IHandler<TInput, TOutput> ConvertedBy<THandlerOutput, TInput, TOutput>(
            [NotNull] this IHandler<TInput, THandlerOutput>                                                    handler,
            [NotNull]      IOutputConverter<IHandler<TInput, THandlerOutput>, THandlerOutput, TInput, TOutput> converter)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new OutputConvertedHandler<IOutputConverter<IHandler<TInput, THandlerOutput>, THandlerOutput, TInput, TOutput>,
                IHandler<TInput, THandlerOutput>,
                THandlerOutput, TInput, TOutput>(converter, handler);
        }

        [NotNull]
        public static IAsyncHandler<TInput, TOutput> ConvertingAsync<THandlerOutput, TInput, TOutput>(
            [NotNull] this IOutputAsyncConverter<IAsyncHandler<TInput, THandlerOutput>, THandlerOutput, TInput, TOutput> converter,
            [NotNull]      IAsyncHandler<TInput, THandlerOutput>                                                         handler)
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new OutputConvertedAsyncHandler<IOutputAsyncConverter<IAsyncHandler<TInput, THandlerOutput>, THandlerOutput, TInput, TOutput>,
                IAsyncHandler<TInput, THandlerOutput>,
                THandlerOutput, TInput, TOutput>(converter, handler);
        }

        [NotNull]
        public static IAsyncHandler<TInput, TOutput> ConvertedByAsync<THandlerOutput, TInput, TOutput>(
            [NotNull] this IAsyncHandler<TInput, THandlerOutput>                                                         handler,
            [NotNull]      IOutputAsyncConverter<IAsyncHandler<TInput, THandlerOutput>, THandlerOutput, TInput, TOutput> converter
        )
        {
            converter = converter ?? throw new ArgumentNullException(nameof(converter));
            handler   = handler   ?? throw new ArgumentNullException(nameof(handler));

            return new OutputConvertedAsyncHandler<IOutputAsyncConverter<IAsyncHandler<TInput, THandlerOutput>, THandlerOutput, TInput, TOutput>,
                IAsyncHandler<TInput, THandlerOutput>,
                THandlerOutput, TInput, TOutput>(converter, handler);
        }
    }
}
