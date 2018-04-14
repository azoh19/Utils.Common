#region Using

using JetBrains.Annotations;
using Utils.Handlers;

#endregion

namespace Utils.Commands.Handlers
{
    [PublicAPI]
    public interface IAsyncCommandHandler<in TCommand> : IAsyncHandler<TCommand, ICommandResult> where TCommand : ICommand
    { }

    [PublicAPI]
    public interface IAsyncCommandHandler<in TCommand, TResult> : IAsyncHandler<TCommand, ICommandResult<TResult>> where TCommand : ICommand<TResult>
    { }
}
