#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Trees.Binary
{
    [PublicAPI]
    public interface IBinaryNode<out TItem>
    {
        [NotNull]
        TItem Item { get; }

        [CanBeNull]
        IBinaryNode<TItem> Left { get; }

        [CanBeNull]
        IBinaryNode<TItem> Right { get; }
    }
}
