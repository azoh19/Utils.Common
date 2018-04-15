#region Using

using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

#endregion

namespace Utils.Tasks
{
    [PublicAPI]
    public static class TaskExtensions
    {
        public static bool IsSucceeded(this Task task) => task.IsCompleted && !task.IsCanceled && !task.IsFaulted;

        [NotNull]
        [ItemCanBeNull]
        public static Task<TDst> Then<TSrc, TDst>([NotNull] this Task<TSrc> task, [NotNull] Func<TSrc, TDst> func)
        {
            TDst Continuation(Task<TSrc> src) => func(src.Result);

            return task.ContinueWith(Continuation);
        }

        [NotNull]
        [ItemCanBeNull]
        public static Task<TDst> Then<TDst>([NotNull] this Task task, [NotNull] Func<TDst> func)
        {
            TDst Continuation(Task src) => func();

            return task.ContinueWith(Continuation);
        }

        [NotNull]
        public static Task Then<TSrc>([NotNull] this Task<TSrc> task, [NotNull] Action<TSrc> action)
        {
            void Continuation(Task<TSrc> src) => action(src.Result);

            return task.ContinueWith(Continuation);
        }

        [NotNull]
        public static Task Then([NotNull] this Task task, [NotNull] Action action)
        {
            void Continuation(Task src) => action();

            return task.ContinueWith(Continuation);
        }
    }
}
