#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.DispatchConfiguration.Configurators
{
    [PublicAPI]
    public interface IOutputAsyncConverterConfigurator<TInput, TOutput, TNewOutput>
    {
        [NotNull]
        IAsyncHandlerConfigurator<TInput, TNewOutput> By<TConverter>()
            where TConverter : IOutputAsyncConverter<TInput, TOutput, TNewOutput>;
    }
}
