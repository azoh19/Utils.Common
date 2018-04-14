#region Using

#endregion

using JetBrains.Annotations;

namespace Utils.Commands
{
    [PublicAPI]
    public interface ICommand
    { }

    [PublicAPI]
    public interface ICommand<out TResult>
    { }
}
