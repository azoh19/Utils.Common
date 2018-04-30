#region Using

using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Utils.AbstractDI;
using Utils.Handlers;

#endregion

namespace Utils.Commands.Dispatchers
{
    [PublicAPI]
    public class AsyncCommandDispatcherBase : IAsyncCommandDispatcher
    {
        [NotNull]
        protected IResolver Resolver { get; }

        protected AsyncCommandDispatcherBase([NotNull] IResolver resolver)
        {
            Resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        #region Implementation of IAsyncCommandDispatcher

        public Task<ICommandResult> DispatchAsync<TCommand>(TCommand command)
            where TCommand : ICommand
            => Resolver.Resolve<IAsyncHandler<TCommand, ICommandResult>>().RunAsync(command);

        public Task<ICommandResult<TResult>> DispatchAsync<TCommand, TResult>(TCommand command)
            where TCommand : ICommand<TResult>
            => Resolver.Resolve<IAsyncHandler<TCommand, ICommandResult<TResult>>>().RunAsync(command);

        #endregion
    }
}
