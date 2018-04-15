#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.DispatchConfiguration
{
    [PublicAPI]
    public interface IInputAsyncConverterConfigurator<TInput, TOutput, out TNewInput>
    {
        IHandlerConfigurator<TInput, TOutput> By<TConverter>()
            where TConverter : IInputAsyncConverter<TInput, TOutput, TNewInput>;
    }
}
