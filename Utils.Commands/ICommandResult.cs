#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Commands
{
    [PublicAPI]
    public interface ICommandResult
    {
        bool   Success { get; }
        string Message { get; }
    }

    [PublicAPI]
    public interface ICommandResult<out TResult> : ICommandResult
    {
        TResult Result { get; }
    }
}
