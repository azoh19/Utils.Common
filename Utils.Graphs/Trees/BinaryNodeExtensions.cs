#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Graphs.Trees
{
    [PublicAPI]
    public static class BinaryNodeExtensions
    {
        public static TNode? FirstChild<TNode>(this TNode current, bool leftToRight) where TNode : class, IBinaryNode<TNode>
            => leftToRight ? current.Left : current.Right;

        public static TNode? SecondChild<TNode>(this TNode current, bool leftToRight) where TNode : class, IBinaryNode<TNode>
            => leftToRight ? current.Right : current.Left;
    }
}
