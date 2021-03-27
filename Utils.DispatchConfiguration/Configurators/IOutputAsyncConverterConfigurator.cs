#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.DispatchConfiguration.Configurators
{
    [PublicAPI]
    public interface IOutputAsyncConverterConfigurator<TInput, TOutput, TNewOutput>
    {
        IAsyncHandlerConfigurator<TInput, TNewOutput> By<TConverter>()
            where TConverter : class, IOutputAsyncConverter<TInput, TOutput, TNewOutput>;
    }
}
