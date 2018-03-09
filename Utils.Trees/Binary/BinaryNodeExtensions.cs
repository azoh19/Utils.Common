#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Trees.Binary
{
    [PublicAPI]
    public static class BinaryNodeExtensions
    {
        public static IBinaryNode<TItem> FirstChild<TItem>(this IBinaryNode<TItem> current, bool leftToRight) => leftToRight ? current.Left : current.Right;

        public static IBinaryNode<TItem> SecondChild<TItem>(this IBinaryNode<TItem> current, bool leftToRight) => leftToRight ? current.Right : current.Left;
    }
}
