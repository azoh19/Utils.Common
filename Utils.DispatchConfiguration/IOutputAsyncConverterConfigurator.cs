#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.DispatchConfiguration
{
    [PublicAPI]
    public interface IOutputAsyncConverterConfigurator<TInput, TOutput, TNewOutput>
    {
        IHandlerConfigurator<TInput, TOutput> By<TConverter>()
            where TConverter : IOutputAsyncConverter<TInput, TOutput, TNewOutput>;
    }
}
