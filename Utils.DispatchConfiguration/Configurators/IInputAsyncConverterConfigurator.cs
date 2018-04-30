#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.DispatchConfiguration.Configurators
{
    [PublicAPI]
    public interface IInputAsyncConverterConfigurator<in TInput, TOutput, TNewInput>
    {
        [NotNull]
        IAsyncHandlerConfigurator<TNewInput, TOutput> By<TConverter>()
            where TConverter : IInputAsyncConverter<TInput, TOutput, TNewInput>;
    }
}
