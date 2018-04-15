#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.DispatchConfiguration
{
    [PublicAPI]
    public interface IConverterConfigurator<TInput, TOutput, out TNewInput, in TNewOutput>
    {
        IHandlerConfigurator<TInput, TOutput> By<TConverter>()
            where TConverter : IConverter<TInput, TOutput, TNewInput, TNewOutput>;
    }
}
