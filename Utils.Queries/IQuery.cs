#region Using

#endregion

using JetBrains.Annotations;

namespace Utils.Queries
{
    [PublicAPI]
    public interface IQuery<out TResult>
    { }
}
