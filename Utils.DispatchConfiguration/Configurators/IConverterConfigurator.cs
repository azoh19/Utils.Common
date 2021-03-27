#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.DispatchConfiguration.Configurators
{
    [PublicAPI]
    public interface IConverterConfigurator<in TInput, out TOutput, TNewInput, TNewOutput>
    {
        IHandlerConfigurator<TNewInput, TNewOutput> By<TConverter>()
            where TConverter : class, IFullConverter<TInput, TOutput, TNewInput, TNewOutput>;
    }
}
