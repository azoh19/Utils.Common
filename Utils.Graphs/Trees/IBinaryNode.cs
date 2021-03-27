#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Graphs.Trees
{
    [PublicAPI]
    public interface IBinaryNode<out TNode> where TNode : class, IBinaryNode<TNode>
    {
        TNode? Left { get; }

        TNode? Right { get; }
    }
}
