#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Dispatchers
{
    [PublicAPI]
    public interface IDispatch
    {
        TOutput Dispatch<TInput, TOutput>(TInput input);
    }
}
