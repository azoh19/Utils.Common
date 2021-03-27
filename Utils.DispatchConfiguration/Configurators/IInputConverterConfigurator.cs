#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.DispatchConfiguration.Configurators
{
    [PublicAPI]
    public interface IInputConverterConfigurator<in TInput, TOutput, TNewInput>
    {
        IHandlerConfigurator<TNewInput, TOutput> By<TConverter>()
            where TConverter : class, IInputConverter<TInput, TOutput, TNewInput>;
    }
}
