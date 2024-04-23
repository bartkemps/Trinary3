namespace Trinary3
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Maps the three possibilities of a trit to a value.
    /// </summary>
    [DebuggerDisplay("({Negative},{Zero},{Positive})")]
    public struct TritMap<TItem> : ITrio<TItem>
    {
        public readonly TItem Negative;
        public readonly TItem Zero;
        public readonly TItem Positive;

        public TritMap(TItem negative, TItem zero, TItem positive)
        {
            Negative = negative;
            Zero = zero;
            Positive = positive;
        }

        public TItem this[Trit index]
        {
            get
            {
                switch (index)
                {
                    case Trit.Negative:
                        return Negative;
                    case Trit.Zero:
                        return Zero;
                    case Trit.Positive:
                        return Positive;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }
    }




}
