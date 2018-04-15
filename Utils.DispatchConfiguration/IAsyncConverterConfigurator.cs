#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.DispatchConfiguration
{
    [PublicAPI]
    public interface IAsyncConverterConfigurator<TInput, TOutput, out TNewInput, TNewOutput>
    {
        IAsyncHandlerConfigurator<TInput, TOutput> By<TConverter>()
            where TConverter : IAsyncConverter<TInput, TOutput, TNewInput, TNewOutput>;
    }
}
