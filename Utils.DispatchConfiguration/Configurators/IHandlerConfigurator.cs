#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;
using Utils.Handlers.Interceptors;

#endregion

namespace Utils.DispatchConfiguration.Configurators
{
    [PublicAPI]
    public interface IHandlerConfigurator<TContainerOptions, TInput, TOutput>
    {
        [NotNull]
        IHandlerConfigurator<TContainerOptions, TInput, TOutput> InterceptBy<TInterceptor>()
            where TInterceptor : IInterceptor<TInput, TOutput>;

        [NotNull]
        IHandlerConfigurator<TContainerOptions, TNewInput, TNewOutput> ConvertBy<TConverter, TNewInput, TNewOutput>()
            where TConverter : IFullConverter<TInput, TOutput, TNewInput, TNewOutput>;

        [NotNull]
        IHandlerConfigurator<TContainerOptions, TNewInput, TOutput> ConvertInputBy<TConverter, TNewInput>()
            where TConverter : IInputConverter<TInput, TOutput, TNewInput>;

        [NotNull]
        IHandlerConfigurator<TContainerOptions, TInput, TNewOutput> ConvertOutputBy<TConverter, TNewOutput>()
            where TConverter : IOutputConverter<TInput, TOutput, TNewOutput>;

        [NotNull]
        IConverterConfigurator<TContainerOptions, TInput, TOutput, TNewInput, TNewOutput> ConvertTo<TNewInput, TNewOutput>();

        [NotNull]
        IInputConverterConfigurator<TContainerOptions, TInput, TOutput, TNewInput> ConvertInputTo<TNewInput>();

        [NotNull]
        IOutputConverterConfigurator<TContainerOptions, TInput, TOutput, TNewOutput> ConvertOutputTo<TNewOutput>();

        [NotNull]
        TContainerOptions Register();
    }
}
