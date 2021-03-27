#region Using

using Utils.DispatchConfiguration.Configurators;

#endregion

namespace Utils.DispatchConfiguration.Infrastructure
{
    internal sealed class InputConverterConfigurator<TInput, TOutput, TNewInput>
        : IInputConverterConfigurator<TInput, TOutput, TNewInput>
    {
        private readonly HandlerConfigurator<TInput, TOutput> _configurator;

        public InputConverterConfigurator(HandlerConfigurator<TInput, TOutput> configurator)
        {
            _configurator = configurator;
        }

        IHandlerConfigurator<TNewInput, TOutput> IInputConverterConfigurator<TInput, TOutput, TNewInput>.By<TConverter>()
            => _configurator.ConvertInputBy<TConverter, TNewInput>();
    }
}
