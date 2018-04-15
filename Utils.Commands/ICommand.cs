#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Commands
{
    [PublicAPI]
    public interface ICommand
    { }

    [PublicAPI]
    public interface ICommand<out TResult>
    { }
}
