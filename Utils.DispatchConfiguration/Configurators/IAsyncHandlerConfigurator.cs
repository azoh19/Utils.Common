#region Using

using System;
using JetBrains.Annotations;
using Utils.AbstractDI;
using Utils.DispatchConfiguration.Infrastructure;
using Utils.Handlers;
using Utils.Handlers.Converters;
using Utils.Handlers.Interceptors;

#endregion

namespace Utils.DispatchConfiguration.Configurators
{
    [PublicAPI]
    public interface IAsyncHandlerConfigurator<TInput, TOutput>
    {
        [NotNull]
        IAsyncHandlerConfigurator<TInput, TOutput> InterceptBy<TInterceptor>()
            where TInterceptor : IAsyncInterceptor<TInput, TOutput>;

        [NotNull]
        IAsyncHandlerConfigurator<TNewInput, TNewOutput> ConvertBy<TConverter, TNewInput, TNewOutput>()
            where TConverter : IFullAsyncConverter<TInput, TOutput, TNewInput, TNewOutput>;

        [NotNull]
        IAsyncHandlerConfigurator<TNewInput, TOutput> ConvertInputBy<TConverter, TNewInput>()
            where TConverter : IInputAsyncConverter<TInput, TOutput, TNewInput>;

        [NotNull]
        IAsyncHandlerConfigurator<TInput, TNewOutput> ConvertOutputBy<TConverter, TNewOutput>()
            where TConverter : IOutputAsyncConverter<TInput, TOutput, TNewOutput>;

        [NotNull]
        IAsyncConverterConfigurator<TInput, TOutput, TNewInput, TNewOutput> ConvertTo<TNewInput, TNewOutput>();

        [NotNull]
        IInputAsyncConverterConfigurator<TInput, TOutput, TNewInput> ConvertInputTo<TNewInput>();

        [NotNull]
        IOutputAsyncConverterConfigurator<TInput, TOutput, TNewOutput> ConvertOutputTo<TNewOutput>();

        [NotNull]
        Func<IResolver, IAsyncHandler<TInput, TOutput>> ResolveFunc { get; }
    }
}
