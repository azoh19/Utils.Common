#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;
using Utils.Handlers.Interceptors;

#endregion

namespace Utils.DispatchConfiguration
{
    [PublicAPI]
    public interface IHandlerConfigurator<TInput, TOutput>
    {
        [NotNull]
        IHandlerConfigurator<TInput, TOutput> Apply<TInterceptor>()
            where TInterceptor : IInterceptor<TInput, TOutput>;

        [NotNull]
        IHandlerConfigurator<TNewInput, TNewOutput> ConvertBy<TConverter, TNewInput, TNewOutput>()
            where TConverter : IConverter<TInput, TOutput, TNewInput, TNewOutput>;

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

        void Register();
    }
}
