#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.DispatchConfiguration.Configurators
{
    [PublicAPI]
    public interface IOutputConverterConfigurator<TContainerOptions, TInput, out TOutput, TNewOutput>
    {
        [NotNull]
        IHandlerConfigurator<TContainerOptions, TInput, TNewOutput> By<TConverter>()
            where TConverter : IOutputConverter<TInput, TOutput, TNewOutput>;
    }
}
