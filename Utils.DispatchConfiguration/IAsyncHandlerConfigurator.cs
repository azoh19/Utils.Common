#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;
using Utils.Handlers.Interceptors;

#endregion

namespace Utils.DispatchConfiguration
{
    [PublicAPI]
    public interface IAsyncHandlerConfigurator<TInput, TOutput>
    {
        [NotNull]
        IHandlerConfigurator<TInput, TOutput> Apply<TInterceptor>()
            where TInterceptor : IAsyncInterceptor<TInput, TOutput>;

        [NotNull]
        IHandlerConfigurator<TNewInput, TNewOutput> ConvertBy<TConverter, TNewInput, TNewOutput>()
            where TConverter : IAsyncConverter<TInput, TOutput, TNewInput, TNewOutput>;

        [NotNull]
        IHandlerConfigurator<TNewInput, TOutput> ConvertInputBy<TConverter, TNewInput>()
            where TConverter : IInputAsyncConverter<TInput, TOutput, TNewInput>;

        [NotNull]
        IHandlerConfigurator<TInput, TNewOutput> ConvertOutputBy<TConverter, TNewOutput>()
            where TConverter : IOutputAsyncConverter<TInput, TOutput, TNewOutput>;

        [NotNull]
        IAsyncConverterConfigurator<TInput, TOutput, TNewInput, TNewOutput> ConvertTo<TNewInput, TNewOutput>();

        [NotNull]
        IInputAsyncConverterConfigurator<TInput, TOutput, TNewInput> ConvertInputTo<TNewInput>();

        [NotNull]
        IOutputAsyncConverterConfigurator<TInput, TOutput, TNewOutput> ConvertOutputTo<TNewOutput>();

        void Register();
    }
}
