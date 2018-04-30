#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.DispatchConfiguration.Configurators
{
    [PublicAPI]
    public interface IInputConverterConfigurator<in TInput, TOutput, TNewInput>
    {
        [NotNull]
        IHandlerConfigurator<TNewInput, TOutput> By<TConverter>()
            where TConverter : IInputConverter<TInput, TOutput, TNewInput>;
    }
}
