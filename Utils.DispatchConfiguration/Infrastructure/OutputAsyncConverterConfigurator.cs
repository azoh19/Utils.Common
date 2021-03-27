#region Using

using Utils.DispatchConfiguration.Configurators;

#endregion

namespace Utils.DispatchConfiguration.Infrastructure
{
    internal sealed class OutputAsyncConverterConfigurator<TInput, TOutput, TNewOutput>
        : IOutputAsyncConverterConfigurator<TInput, TOutput, TNewOutput>
    {
        private readonly AsyncHandlerConfigurator<TInput, TOutput> _configurator;

        public OutputAsyncConverterConfigurator(AsyncHandlerConfigurator<TInput, TOutput> configurator)
        {
            _configurator = configurator;
        }

        IAsyncHandlerConfigurator<TInput, TNewOutput> IOutputAsyncConverterConfigurator<TInput, TOutput, TNewOutput>.By<TConverter>()
            => _configurator.ConvertOutputBy<TConverter, TNewOutput>();
    }
}
