#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.DispatchConfiguration
{
    [PublicAPI]
    public interface IInputConverterConfigurator<TInput, TOutput, out TNewInput>
    {
        IHandlerConfigurator<TInput, TOutput> By<TConverter>()
            where TConverter : IInputConverter<TInput, TOutput, TNewInput>;
    }
}
