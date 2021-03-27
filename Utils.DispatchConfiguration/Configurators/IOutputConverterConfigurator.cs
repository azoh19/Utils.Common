#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.DispatchConfiguration.Configurators
{
    [PublicAPI]
    public interface IOutputConverterConfigurator<TInput, out TOutput, TNewOutput>
    {
        IHandlerConfigurator<TInput, TNewOutput> By<TConverter>()
            where TConverter : class, IOutputConverter<TInput, TOutput, TNewOutput>;
    }
}
