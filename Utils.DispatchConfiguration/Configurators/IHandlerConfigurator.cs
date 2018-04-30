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
    public interface IHandlerConfigurator<TInput, TOutput>
    {
        [NotNull]
        IHandlerConfigurator<TInput, TOutput> InterceptBy<TInterceptor>()
            where TInterceptor : IInterceptor<TInput, TOutput>;

        [NotNull]
        IHandlerConfigurator<TNewInput, TNewOutput> ConvertBy<TConverter, TNewInput, TNewOutput>()
            where TConverter : IFullConverter<TInput, TOutput, TNewInput, TNewOutput>;

        [NotNull]
        IHandlerConfigurator<TNewInput, TOutput> ConvertInputBy<TConverter, TNewInput>()
            where TConverter : IInputConverter<TInput, TOutput, TNewInput>;

        [NotNull]
        IHandlerConfigurator<TInput, TNewOutput> ConvertOutputBy<TConverter, TNewOutput>()
            where TConverter : IOutputConverter<TInput, TOutput, TNewOutput>;

        [NotNull]
        IConverterConfigurator<TInput, TOutput, TNewInput, TNewOutput> ConvertTo<TNewInput, TNewOutput>();

        [NotNull]
        IInputConverterConfigurator<TInput, TOutput, TNewInput> ConvertInputTo<TNewInput>();

        [NotNull]
        IOutputConverterConfigurator<TInput, TOutput, TNewOutput> ConvertOutputTo<TNewOutput>();

        [NotNull]
        Func<IResolver, IHandler<TInput, TOutput>> ResolveFunc { get; }
    }
}
