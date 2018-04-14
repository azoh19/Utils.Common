#region Using

#endregion

namespace Utils.Queries
{
    [PublicAPI]
    public interface IQueryDispatcher
    {
        TResult Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}
