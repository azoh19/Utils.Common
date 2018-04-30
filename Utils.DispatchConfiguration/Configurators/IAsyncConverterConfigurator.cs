#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.DispatchConfiguration.Configurators
{
    [PublicAPI]
    public interface IAsyncConverterConfigurator<in TInput, TOutput, TNewInput, TNewOutput>
    {
        [NotNull]
        IAsyncHandlerConfigurator<TNewInput, TNewOutput> By<TConverter>()
            where TConverter : IFullAsyncConverter<TInput, TOutput, TNewInput, TNewOutput>;
    }
}
