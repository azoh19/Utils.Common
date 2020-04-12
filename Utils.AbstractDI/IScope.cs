#region Using

using System;
using JetBrains.Annotations;

#endregion

namespace Utils.AbstractDI
{
    [PublicAPI]
    public interface IScope : IDisposable
    {
        [NotNull]
        IScope BeginScope();

        [NotNull]
        IResolver GetResolver();
    }
}
