using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBinaryTree
{
    /// <summary>
    /// Tree state enumeration.
    /// </summary>
    public enum TreeState
    {
        /// <summary>
        /// Tree balanced.
        /// </summary>
        Balanced,
        /// <summary>
        /// Left branch is too long.
        /// </summary>
        LeftHeavy,
        /// <summary>
        /// Right branch is too long.
        /// </summary>
        RightHeavy,
    }
}
