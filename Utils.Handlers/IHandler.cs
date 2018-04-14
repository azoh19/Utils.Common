#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Handlers
{
    [PublicAPI]
    public interface IHandler<in TInput, out TOutput>
    {
        TOutput Run(TInput input);
    }
}
