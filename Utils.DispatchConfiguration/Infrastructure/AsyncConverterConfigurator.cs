#region Using

using Utils.DispatchConfiguration.Configurators;

#endregion

namespace Utils.DispatchConfiguration.Infrastructure
{
    internal sealed class AsyncConverterConfigurator<TInput, TOutput, TNewInput, TNewOutput>
        : IAsyncConverterConfigurator<TInput, TOutput, TNewInput, TNewOutput>
    {
        private readonly AsyncHandlerConfigurator<TInput, TOutput> _configurator;

        public AsyncConverterConfigurator(AsyncHandlerConfigurator<TInput, TOutput> configurator)
        {
            _configurator = configurator;
        }

        IAsyncHandlerConfigurator<TNewInput, TNewOutput> IAsyncConverterConfigurator<TInput, TOutput, TNewInput, TNewOutput>.
            By<TConverter>()
            => _configurator.ConvertBy<TConverter, TNewInput, TNewOutput>();
    }
}
