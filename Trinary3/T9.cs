namespace Trinary3
{
    using System.Diagnostics;

    /// <summary>
    /// Maps the nine posibillities of a pair of trits to a value.
    /// </summary>
    [DebuggerDisplay("{Value}")]
    public readonly struct T9<TItem> : ITrio<ITrio<TItem>>
    {
        public readonly T3<T3<TItem>> Value;

        ITrio<TItem> ITrio<ITrio<TItem>>.Negative => Value.Negative;
        ITrio<TItem> ITrio<ITrio<TItem>>.Zero => Value.Zero;
        ITrio<TItem> ITrio<ITrio<TItem>>.Positive => Value.Positive;

        public T9(T3<TItem> negative, T3<TItem> zero, T3<TItem> positive)
        {
            Value = new T3<T3<TItem>>(negative, zero, positive);
        }

        public T9(TItem negativeNegative, TItem negativeZero, TItem negativePositive,
            TItem zeroNegative, TItem zeroZero, TItem zeroPositive,
            TItem positiveNegative, TItem positiveZero, TItem positivePositive)
        {
            Value = new T3<T3<TItem>>(
                new T3<TItem>(negativeNegative, negativeZero, negativePositive),
                new T3<TItem>(zeroNegative, zeroZero, zeroPositive),
                new T3<TItem>(positiveNegative, positiveZero, positivePositive));
        }

        public TItem this[Trit row, Trit column] => Value[row][column];

        ITrio<TItem> ITrio<ITrio<TItem>>.this[Trit index] => Value[index];

        public T3<TItem> this[Trit index] => Value[index];
    }




}
