#region Using

using System;
using System.Collections.Generic;
using JetBrains.Annotations;

#endregion

namespace Utils.Graphs.Trees
{
    [PublicAPI]
    public static class DepthTraversalExtensions
    {
        [ItemNotNull]
        public static IEnumerable<TNode> DepthTraversal<TNode>(this TNode node, DepthTraversalOrder order, bool leftToRight = true)
            where TNode : class, IBinaryNode<TNode>
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            return order switch
                   {
                       DepthTraversalOrder.Pre  => PreOrderIterator(node, leftToRight),
                       DepthTraversalOrder.In   => InOrderIterator(node, leftToRight),
                       DepthTraversalOrder.Post => PostOrderIterator(node, leftToRight),
                       _                        => throw new ArgumentOutOfRangeException(nameof(order), order, null)
                   };
        }

        private static IEnumerable<TNode> PreOrderIterator<TNode>(TNode node, bool leftToRight) where TNode : class, IBinaryNode<TNode>
        {
            var stack = new Stack<TNode>(new[] { node });

            void Push(TNode? item)
            {
                if (item != null)
                    stack.Push(item);
            }

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                yield return current;

                Push(current.SecondChild(leftToRight));
                Push(current.FirstChild(leftToRight));
            }
        }

        private static IEnumerable<TNode> InOrderIterator<TNode>(TNode node, bool leftToRight) where TNode : class, IBinaryNode<TNode>
        {
            var stack = new Stack<TNode>();

            var current = node;

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
                    yield return current;

                    current = current.SecondChild(leftToRight);
                }
            }
        }

        private static IEnumerable<TNode> PostOrderIterator<TNode>(TNode node, bool leftToRight) where TNode : class, IBinaryNode<TNode>
        {
            var stack = new Stack<TNode>();

            var    current = node;
            TNode? last    = null;

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

                    if ((second != null) && (last != second))
                        current = second;
                    else
                    {
                        yield return peek;

                        last = stack.Pop();
                    }
                }
            }
        }
    }
}
