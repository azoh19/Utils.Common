#region Using

using JetBrains.Annotations;
using Utils.Handlers;

#endregion

namespace Utils.Queries.Handlers
{
    [PublicAPI]
    public interface IQueryHandler<in TQuery, out TResult> : IHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    { }
}
