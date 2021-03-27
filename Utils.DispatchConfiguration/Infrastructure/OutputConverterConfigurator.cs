#region Using

using Utils.DispatchConfiguration.Configurators;

#endregion

namespace Utils.DispatchConfiguration.Infrastructure
{
    internal sealed class OutputConverterConfigurator<TInput, TOutput, TNewOutput>
        : IOutputConverterConfigurator<TInput, TOutput, TNewOutput>
    {
        private readonly HandlerConfigurator<TInput, TOutput> _configurator;

        public OutputConverterConfigurator(HandlerConfigurator<TInput, TOutput> configurator)
        {
            _configurator = configurator;
        }

        IHandlerConfigurator<TInput, TNewOutput> IOutputConverterConfigurator<TInput, TOutput, TNewOutput>.By<TConverter>()
            => _configurator.ConvertOutputBy<TConverter, TNewOutput>();
    }
}
