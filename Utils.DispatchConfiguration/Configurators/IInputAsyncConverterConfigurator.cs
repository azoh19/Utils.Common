#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.DispatchConfiguration.Configurators
{
    [PublicAPI]
    public interface IInputAsyncConverterConfigurator<in TInput, TOutput, TNewInput>
    {
        IAsyncHandlerConfigurator<TNewInput, TOutput> By<TConverter>()
            where TConverter : class, IInputAsyncConverter<TInput, TOutput, TNewInput>;
    }
}
