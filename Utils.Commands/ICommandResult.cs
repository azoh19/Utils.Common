#region Using

#endregion

namespace Utils.Commands.Commands
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
