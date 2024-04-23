using System;
using System.Diagnostics;
using System.Text;
using Trinary3;

namespace Trinary3
{
    /// <summary>
    /// A single unit af a Trinary number, having a value of either T (-1), 0, or 1.
    /// </summary>
    public enum Trit : sbyte
    {
        /// <summary>
        /// A value of T (decimal -1).
        /// </summary>
        Negative = -1,
        /// <summary>
        /// A value of 0.
        /// </summary>
        Zero = 0,
        /// <summary>
        /// A value of 1.
        /// </summary>
        Positive = 1
    }
}