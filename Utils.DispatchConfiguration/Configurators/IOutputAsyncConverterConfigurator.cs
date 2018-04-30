#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.DispatchConfiguration.Configurators
{
    [PublicAPI]
    public interface IOutputAsyncConverterConfigurator<TContainerOptions, TInput, TOutput, TNewOutput>
    {
        [NotNull]
        IAsyncHandlerConfigurator<TContainerOptions, TInput, TNewOutput> By<TConverter>()
            where TConverter : IOutputAsyncConverter<TInput, TOutput, TNewOutput>;
    }
}
