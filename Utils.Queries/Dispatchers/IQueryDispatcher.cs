#region Using

#endregion

using JetBrains.Annotations;

namespace Utils.Queries.Dispatchers
{
    [PublicAPI]
    public interface IQueryDispatcher
    {
        TResult Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}
