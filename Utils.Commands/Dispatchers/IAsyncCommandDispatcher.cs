#region Using

using System.Threading.Tasks;
using JetBrains.Annotations;

#endregion

namespace Utils.Commands.Dispatchers
{
    [PublicAPI]
    public interface IAsyncCommandDispatcher
    {
        Task<ICommandResult> DispatchAsync<TCommand>(TCommand command);

        Task<ICommandResult<TResult>> DispatchAsync<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>;
    }
}
