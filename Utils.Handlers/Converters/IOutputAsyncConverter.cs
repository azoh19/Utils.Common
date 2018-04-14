#region Using

using System.Threading.Tasks;
using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Converters
{
    [PublicAPI]
    public interface IOutputAsyncConverter<in THandler, THandlerOutput, in TInput, TOutput>
        where THandler : IAsyncHandler<TInput, THandlerOutput>
    {
        [NotNull]
        [ItemCanBeNull]
        Task<TOutput> ConvertAsync([NotNull] THandler handler, [NotNull] TInput output);
    }
}
