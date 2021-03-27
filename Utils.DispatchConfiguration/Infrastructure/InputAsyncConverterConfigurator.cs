#region Using

using Utils.DispatchConfiguration.Configurators;

#endregion

namespace Utils.DispatchConfiguration.Infrastructure
{
    internal sealed class InputAsyncConverterConfigurator<TInput, TOutput, TNewInput>
        : IInputAsyncConverterConfigurator<TInput, TOutput, TNewInput>
    {
        private readonly AsyncHandlerConfigurator<TInput, TOutput> _configurator;

        public InputAsyncConverterConfigurator(AsyncHandlerConfigurator<TInput, TOutput> configurator)
        {
            _configurator = configurator;
        }

        IAsyncHandlerConfigurator<TNewInput, TOutput> IInputAsyncConverterConfigurator<TInput, TOutput, TNewInput>.By<TConverter>()
            => _configurator.ConvertInputBy<TConverter, TNewInput>();
    }
}
