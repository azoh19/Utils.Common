#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.DispatchConfiguration.Configurators
{
    [PublicAPI]
    public interface IConverterConfigurator<TContainerOptions, in TInput, out TOutput, TNewInput, TNewOutput>
    {
        [NotNull]
        IHandlerConfigurator<TContainerOptions, TNewInput, TNewOutput> By<TConverter>()
            where TConverter : IFullConverter<TInput, TOutput, TNewInput, TNewOutput>;
    }
}
