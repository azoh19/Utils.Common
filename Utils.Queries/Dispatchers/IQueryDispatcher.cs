#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Queries.Dispatchers
{
    [PublicAPI]
    public interface IQueryDispatcher
    {
        TResult Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}
