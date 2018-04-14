#region Using

using System.Threading.Tasks;
using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Converters
{
    [PublicAPI]
    public interface IAsyncConverter<in THandler, THandlerInput, THandlerOutput, in TInput, TOutput>
        where THandler : IAsyncHandler<THandlerInput, THandlerOutput>
    {
        [NotNull]
        [ItemCanBeNull]
        Task<TOutput> ConvertAsync([NotNull] THandler handler, [NotNull] TInput output);
    }
}
