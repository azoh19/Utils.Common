#region Using

using JetBrains.Annotations;
using Utils.Handlers.Commands;

#endregion

namespace Utils.Handlers.Handlers
{
    [PublicAPI]
    public interface ICommandHandler<in TCommand> : IHandler<TCommand, ICommandResult> where TCommand : ICommand
    { }

    [PublicAPI]
    public interface ICommandHandler<in TCommand, out TResult> : IHandler<TCommand, ICommandResult<TResult>> where TCommand : ICommand<TResult>
    { }
}
