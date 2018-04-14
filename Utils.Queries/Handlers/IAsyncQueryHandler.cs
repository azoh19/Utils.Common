#region Using

using JetBrains.Annotations;
using Utils.Handlers.Queries;

#endregion

namespace Utils.Handlers.Handlers
{
    [PublicAPI]
    public interface IAsyncQueryHandler<in TQuery, TResult> : IAsyncHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    { }
}
