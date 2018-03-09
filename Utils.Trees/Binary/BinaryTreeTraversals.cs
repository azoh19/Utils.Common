#region Using

using System;
using System.Collections.Generic;
using JetBrains.Annotations;

#endregion

namespace Utils.Trees.Binary
{
    [PublicAPI]
    public static class DepthTraversalExtension
    {
        [NotNull]
        [ItemNotNull]
        public static IEnumerable<TItem> DepthTraversal<TItem>([NotNull] this IBinaryNode<TItem> node, DepthTraversalOrder order, bool leftToRight = true)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            switch (order)
            {
                case DepthTraversalOrder.Pre:
                    return PreOrderIterator(node, leftToRight);
                case DepthTraversalOrder.In:
                    return InOrderIterator(node, leftToRight);
                case DepthTraversalOrder.Post:
                    return PostOrderIterator(node, leftToRight);
                default:
                    throw new ArgumentOutOfRangeException(nameof(order), order, null);
            }
        }

        private static IEnumerable<TItem> PreOrderIterator<TItem>(IBinaryNode<TItem> node, bool leftToRight)
        {
            var stack = new Stack<IBinaryNode<TItem>>(new[] { node });

            void Push(IBinaryNode<TItem> item)
            {
                if (item != null)
                    stack.Push(item);
            }

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                yield return current.Item;

                Push(current.SecondChild(leftToRight));
                Push(current.FirstChild(leftToRight));
            }
        }

        private static IEnumerable<TItem> InOrderIterator<TItem>(IBinaryNode<TItem> current, bool leftToRight)
        {
            var stack = new Stack<IBinaryNode<TItem>>();

            while ((current != null) || (stack.Count > 0))
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.FirstChild(leftToRight);
                }
                else
                {
                    current = stack.Pop();
                    yield return current.Item;

                    current = current.SecondChild(leftToRight);
                }
            }
        }

        private static IEnumerable<TItem> PostOrderIterator<TItem>(IBinaryNode<TItem> current, bool leftToRight)
        {
            var stack = new Stack<IBinaryNode<TItem>>();

            IBinaryNode<TItem> lastVisited = null;

            while ((current != null) || (stack.Count > 0))
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.FirstChild(leftToRight);
                }
                else
                {
                    var peek   = stack.Peek();
                    var second = peek.SecondChild(leftToRight);

                    if ((second != null) && (lastVisited != second))
                        current = second;
                    else
                    {
                        yield return peek.Item;

                        lastVisited = stack.Pop();
                    }
                }
            }
        }
    }
}
