#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;
using Utils.Handlers.Interceptors;

#endregion

namespace Utils.DispatchConfiguration.Configurators
{
    [PublicAPI]
    public interface IAsyncHandlerConfigurator<TContainerOptions, TInput, TOutput>
    {
        [NotNull]
        IAsyncHandlerConfigurator<TContainerOptions, TInput, TOutput> InterceptBy<TInterceptor>()
            where TInterceptor : IAsyncInterceptor<TInput, TOutput>;

        [NotNull]
        IAsyncHandlerConfigurator<TContainerOptions, TNewInput, TNewOutput> ConvertBy<TConverter, TNewInput, TNewOutput>()
            where TConverter : IFullAsyncConverter<TInput, TOutput, TNewInput, TNewOutput>;

        [NotNull]
        IAsyncHandlerConfigurator<TContainerOptions, TNewInput, TOutput> ConvertInputBy<TConverter, TNewInput>()
            where TConverter : IInputAsyncConverter<TInput, TOutput, TNewInput>;

        [NotNull]
        IAsyncHandlerConfigurator<TContainerOptions, TInput, TNewOutput> ConvertOutputBy<TConverter, TNewOutput>()
            where TConverter : IOutputAsyncConverter<TInput, TOutput, TNewOutput>;

        [NotNull]
        IAsyncConverterConfigurator<TContainerOptions, TInput, TOutput, TNewInput, TNewOutput> ConvertTo<TNewInput, TNewOutput>();

        [NotNull]
        IInputAsyncConverterConfigurator<TContainerOptions, TInput, TOutput, TNewInput> ConvertInputTo<TNewInput>();

        [NotNull]
        IOutputAsyncConverterConfigurator<TContainerOptions, TInput, TOutput, TNewOutput> ConvertOutputTo<TNewOutput>();

        [NotNull]
        TContainerOptions Register();
    }
}
