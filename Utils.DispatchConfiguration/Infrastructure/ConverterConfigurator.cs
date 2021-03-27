#region Using

using Utils.DispatchConfiguration.Configurators;

#endregion

namespace Utils.DispatchConfiguration.Infrastructure
{
    internal sealed class ConverterConfigurator<TInput, TOutput, TNewInput, TNewOutput>
        : IConverterConfigurator<TInput, TOutput, TNewInput, TNewOutput>
    {
        private readonly HandlerConfigurator<TInput, TOutput> _configurator;

        public ConverterConfigurator(HandlerConfigurator<TInput, TOutput> configurator)
        {
            _configurator = configurator;
        }

        IHandlerConfigurator<TNewInput, TNewOutput> IConverterConfigurator<TInput, TOutput, TNewInput, TNewOutput>.By<TConverter>()
            => _configurator.ConvertBy<TConverter, TNewInput, TNewOutput>();
    }
}
