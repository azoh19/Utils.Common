#region Using

using JetBrains.Annotations;
using Utils.Handlers.Queries;

#endregion

namespace Utils.Handlers.Handlers
{
    [PublicAPI]
    public interface IQueryHandler<in TQuery, out TResult> : IHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    { }
}
