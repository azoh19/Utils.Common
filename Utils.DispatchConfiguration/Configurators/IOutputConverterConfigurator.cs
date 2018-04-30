#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.DispatchConfiguration.Configurators
{
    [PublicAPI]
    public interface IOutputConverterConfigurator<TInput, out TOutput, TNewOutput>
    {
        [NotNull]
        IHandlerConfigurator<TInput, TNewOutput> By<TConverter>()
            where TConverter : IOutputConverter<TInput, TOutput, TNewOutput>;
    }
}
