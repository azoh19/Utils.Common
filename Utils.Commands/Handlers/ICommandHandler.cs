#region Using

using JetBrains.Annotations;
using Utils.Handlers;

#endregion

namespace Utils.Commands.Handlers
{
    [PublicAPI]
    public interface ICommandHandler<in TCommand> : IHandler<TCommand, ICommandResult> where TCommand : ICommand
    { }

    [PublicAPI]
    public interface ICommandHandler<in TCommand, out TResult> : IHandler<TCommand, ICommandResult<TResult>> where TCommand : ICommand<TResult>
    { }
}
