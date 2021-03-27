#region Using

using System;
using JetBrains.Annotations;

#endregion

namespace Utils.AbstractDI
{
    [PublicAPI]
    public interface IScope : IDisposable
    {
        IScope BeginScope();

        IResolver GetResolver();
    }
}
