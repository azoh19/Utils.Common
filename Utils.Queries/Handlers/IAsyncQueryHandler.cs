#region Using

using JetBrains.Annotations;
using Utils.Handlers;

#endregion

namespace Utils.Queries.Handlers
{
    [PublicAPI]
    public interface IAsyncQueryHandler<in TQuery, TResult> : IAsyncHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    { }
}
