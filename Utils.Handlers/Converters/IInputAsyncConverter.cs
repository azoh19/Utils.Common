#region Using

using System.Threading.Tasks;
using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Converters
{
    [PublicAPI]
    public interface IInputAsyncConverter<in THandler, THandlerInput, in TInput, TOutput>
        where THandler : IAsyncHandler<THandlerInput, TOutput>
    {
        [NotNull]
        [ItemCanBeNull]
        Task<TOutput> ConvertAsync([NotNull] THandler handler, [NotNull] TInput output);
    }
}
