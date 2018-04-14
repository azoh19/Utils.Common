#region Using

using Utils.Commands.Commands;

#endregion

namespace Utils.Commands
{
    [PublicAPI]
    public interface ICommandDispatcher
    {
        ICommandResult Dispatch<TCommand>(TCommand command);

        ICommandResult<TResult> Dispatch<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>;
    }
}
