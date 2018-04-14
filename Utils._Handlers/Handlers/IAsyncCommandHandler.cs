#region Using

using JetBrains.Annotations;
using Utils.Handlers.Commands;

#endregion

namespace Utils.Handlers.Handlers
{
    [PublicAPI]
    public interface IAsyncCommandHandler<in TCommand> : IAsyncHandler<TCommand, ICommandResult> where TCommand : ICommand
    { }

    [PublicAPI]
    public interface IAsyncCommandHandler<in TCommand, TResult> : IAsyncHandler<TCommand, ICommandResult<TResult>> where TCommand : ICommand<TResult>
    { }
}
