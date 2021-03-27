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
        protected CommandDispatcherBase(IResolver resolver)
        {
            Resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }


        protected IResolver Resolver { get; }

        public ICommandResult Dispatch<TCommand>(TCommand command)
            where TCommand : ICommand
            => Resolver.Resolve<IHandler<TCommand, ICommandResult>>().Handle(command);

        public ICommandResult<TResult> Dispatch<TCommand, TResult>(TCommand command)
            where TCommand : ICommand<TResult>
            => Resolver.Resolve<IHandler<TCommand, ICommandResult<TResult>>>().Handle(command);
    }
}
