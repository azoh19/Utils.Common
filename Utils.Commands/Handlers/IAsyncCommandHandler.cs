#region Using

using JetBrains.Annotations;
using Utils.Handlers;
using Utils.Handlers.Interceptors;

#endregion

namespace Utils.Commands.Handlers
{
    [PublicAPI]
    public interface IAsyncCommandHandler<in TCommand> : IAsyncHandler<TCommand, ICommandResult> where TCommand : ICommand
    { }

    [PublicAPI]
    public interface IAsyncCommandHandler<in TCommand, TResult> : IAsyncHandler<TCommand, ICommandResult<TResult>> where TCommand : ICommand<TResult>
    { }

    [PublicAPI]
    public interface IAsyncCommandInterceptor<TCommand> : IAsyncInterceptor<TCommand, ICommandResult> where TCommand : ICommand
    { }

    [PublicAPI]
    public interface IAsyncCommandInterceptor<TCommand, out TResult> : IAsyncInterceptor<TCommand, ICommandResult> where TCommand : ICommand<TResult>
    { }
}
