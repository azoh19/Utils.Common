#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.DispatchConfiguration
{
    [PublicAPI]
    public interface IOutputConverterConfigurator<TInput, TOutput, in TNewOutput>
    {
        IHandlerConfigurator<TInput, TOutput> By<TConverter>()
            where TConverter : IOutputConverter<TInput, TOutput, TNewOutput>;
    }
}
