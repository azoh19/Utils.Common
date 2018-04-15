#region Using

#endregion

#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Queries
{
    [PublicAPI]
    public interface IQuery<out TResult>
    { }
}
