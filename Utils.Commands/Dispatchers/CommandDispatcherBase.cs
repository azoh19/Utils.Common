#region Using

using System;
using JetBrains.Annotations;
using Utils.AbstractDI;
using Utils.Handlers;

#endregion

namespace Utils.Commands.Dispatchers
{
    [PublicAPI]
    public class CommandDispatcherBase : ICommandDispatcher
    {
        [NotNull]
        protected IResolver Resolver { get; }

        protected CommandDispatcherBase([NotNull] IResolver resolver)
        {
            Resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        #region Implementation of ICommandDispatcher

        public ICommandResult Dispatch<TCommand>(TCommand command)
            where TCommand : ICommand
            => Resolver.Resolve<IHandler<TCommand, ICommandResult>>().Run(command);

        public ICommandResult<TResult> Dispatch<TCommand, TResult>(TCommand command)
            where TCommand : ICommand<TResult>
            => Resolver.Resolve<IHandler<TCommand, ICommandResult<TResult>>>().Run(command);

        #endregion
    }
}
