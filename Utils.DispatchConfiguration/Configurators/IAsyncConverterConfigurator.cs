#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.DispatchConfiguration.Configurators
{
    [PublicAPI]
    public interface IAsyncConverterConfigurator<in TInput, TOutput, TNewInput, TNewOutput>
    {
        IAsyncHandlerConfigurator<TNewInput, TNewOutput> By<TConverter>()
            where TConverter : class, IFullAsyncConverter<TInput, TOutput, TNewInput, TNewOutput>;
    }
}
