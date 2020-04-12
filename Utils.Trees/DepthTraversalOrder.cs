﻿#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Trees
{
    [PublicAPI]
    public enum DepthTraversalOrder
    {
        Pre  = -1,
        In   = 0,
        Post = +1,
    }
}