#region Using

using System;
using System.Collections.Generic;
using JetBrains.Annotations;

#endregion

namespace Utils.Graphs.Trees
{
    [PublicAPI]
    public static class BreadthTraversalExtension
    {
        [ItemNotNull]
        public static IEnumerable<TNode> BreadthTraversal<TNode>(this TNode node, bool leftToRight = true)
            where TNode : class, IBinaryNode<TNode>
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            return BreadthIterator(node, leftToRight);
        }

        private static IEnumerable<TNode> BreadthIterator<TNode>(TNode node, bool leftToRight) where TNode : class, IBinaryNode<TNode>
        {
            var queue = new Queue<TNode>(new[] { node });

            void EnqueueItem(TNode? item)
            {
                if (item != null) queue.Enqueue(item);
            }

            void EnqueueChildren(TNode cur)
            {
                EnqueueItem(cur.FirstChild(leftToRight));
                EnqueueItem(cur.SecondChild(leftToRight));
            }

            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();

                yield return cur;

                EnqueueChildren(cur);
            }
        }
    }
}
