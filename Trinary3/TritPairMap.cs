namespace Trinary3
{
    using System.Diagnostics;

    /// <summary>
    /// Maps the nine posibillities of a pair of trits to a value.
    /// </summary>
    [DebuggerDisplay("{Value}")]
    public struct TritPairMap<TItem> : INono<TItem>
    {
        public readonly TritMap<TritMap<TItem>> Value;

        public TritPairMap(TritMap<TItem> negative, TritMap<TItem> zero, TritMap<TItem> positive)
        {
            Value = new TritMap<TritMap<TItem>>(negative, zero, positive);
        }

        public TritPairMap(TItem negativeNegative, TItem negativeZero, TItem negativePositive,
            TItem zeroNegative, TItem zeroZero, TItem zeroPositive,
            TItem positiveNegative, TItem positiveZero, TItem positivePositive)
        {
            Value = new TritMap<TritMap<TItem>>(
                new TritMap<TItem>(negativeNegative, negativeZero, negativePositive),
                new TritMap<TItem>(zeroNegative, zeroZero, zeroPositive),
                new TritMap<TItem>(positiveNegative, positiveZero, positivePositive));
        }

        public TItem this[Trit row, Trit column] => Value[row][column];

        ITrio<TItem> ITrio<ITrio<TItem>>.this[Trit index] => Value[index];

        public TritMap<TItem> this[Trit index] => Value[index];
    }




}
