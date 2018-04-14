﻿#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Commands.Dispatchers
{
    [PublicAPI]
    public interface ICommandDispatcher
    {
        ICommandResult Dispatch<TCommand>(TCommand command);

        ICommandResult<TResult> Dispatch<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>;
    }
}
