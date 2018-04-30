#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.DispatchConfiguration.Configurators
{
    [PublicAPI]
    public interface IInputConverterConfigurator<TContainerOptions, in TInput, TOutput, TNewInput>
    {
        [NotNull]
        IHandlerConfigurator<TContainerOptions, TNewInput, TOutput> By<TConverter>()
            where TConverter : IInputConverter<TInput, TOutput, TNewInput>;
    }
}
