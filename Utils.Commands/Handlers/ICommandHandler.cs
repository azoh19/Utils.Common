#region Using

using JetBrains.Annotations;
using Utils.Handlers;
using Utils.Handlers.Interceptors;

#endregion

namespace Utils.Commands.Handlers
{
    [PublicAPI]
    public interface ICommandHandler<in TCommand> : IHandler<TCommand, ICommandResult> where TCommand : ICommand
    { }

    [PublicAPI]
    public interface ICommandHandler<in TCommand, out TResult> : IHandler<TCommand, ICommandResult<TResult>> where TCommand : ICommand<TResult>
    { }

    [PublicAPI]
    public interface ICommandInterceptor<TCommand> : IInterceptor<TCommand, ICommandResult> where TCommand : ICommand
    { }

    [PublicAPI]
    public interface ICommandInterceptor<TCommand, out TResult> : IInterceptor<TCommand, ICommandResult> where TCommand : ICommand<TResult>
    { }
}
