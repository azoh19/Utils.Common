#region Using

using System;
using System.Collections.Generic;
using JetBrains.Annotations;

#endregion

namespace Utils.Trees.Binary
{
    [PublicAPI]
    public static class BreadthTraversalExtension
    {
        [NotNull]
        [ItemNotNull]
        public static IEnumerable<TItem> BreadthTraversal<TItem>([NotNull] this IBinaryNode<TItem> node, bool leftToRight = true)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            return BreadthIterator(node, leftToRight);
        }

        private static IEnumerable<TItem> BreadthIterator<TItem>(IBinaryNode<TItem> node, bool leftToRight)
        {
            var queue = new Queue<IBinaryNode<TItem>>(new[] { node });

            void EnqueueItem(IBinaryNode<TItem> item)
            {
                if (item != null) queue.Enqueue(item);
            }

            void EnqueueChildren(IBinaryNode<TItem> cur)
            {
                EnqueueItem(cur.FirstChild(leftToRight));
                EnqueueItem(cur.SecondChild(leftToRight));
            }

            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();

                yield return cur.Item;

                EnqueueChildren(cur);
            }
        }
    }
}
