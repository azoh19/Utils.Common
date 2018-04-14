#region Using

using System.Threading.Tasks;
using Utils.Commands.Commands;

#endregion

namespace Utils.Commands
{
    [PublicAPI]
    public interface IAsyncCommandDispatcher
    {
        Task<ICommandResult> DispatchAsync<TCommand>(TCommand command);

        Task<ICommandResult<TResult>> DispatchAsync<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>;
    }
}
