namespace Trinary3.General
{
    using System;

    internal class TritMapper
    {
        internal static Trit[] TritwiseMap(ITrio<Trit> map, int minNumberOfTrits, Trit[] trits)
        {
            if (minNumberOfTrits < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minNumberOfTrits), minNumberOfTrits, "The minimum number of trits must be non-negative.");
            }
            SetMinimumNumberOfTrits(minNumberOfTrits, ref trits);
            for (int i = 0; i < trits.Length; i++)
            {
                trits[i] = map[trits[i]];
            }

            return trits;
        }

        internal static void TritwiseMap(ITrio<ITrio<Trit>> map, ref int minNumberOfTrits, int maxNumberOfTrits, ref Trit[] trits1, ref Trit[] trits2)
        {
            if (minNumberOfTrits <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minNumberOfTrits), minNumberOfTrits, "The minimum number of trits must be positive.");
            }
            if (maxNumberOfTrits < minNumberOfTrits)
            {
                throw new ArgumentOutOfRangeException(nameof(maxNumberOfTrits), maxNumberOfTrits, "The maximum number of trits must at least be the minimum number of trits.");
            }
            minNumberOfTrits = Math.Max(minNumberOfTrits, Math.Max(trits1.Length, trits2.Length));
            SetMinimumNumberOfTrits(minNumberOfTrits, ref trits1);
            SetMinimumNumberOfTrits(minNumberOfTrits, ref trits2);
            for (int i = 0; i < trits1.Length; i++)
            {
                trits1[i] = map[trits1[i]][trits2[i]];
            }
        }

        /// <param name="minNumberOfTrits">
        /// The minimum number of trits the result should have.
        /// When a pair of zero input trits map to a non-zero output trit, 
        /// the resulting number will be dependent on the number of trits.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        internal static void SetMinimumNumberOfTrits(int minNumberOfTrits, ref Trit[] trits)
        {
            if (trits.Length < minNumberOfTrits)
            {
                Array.Reverse(trits);
                Array.Resize(ref trits, minNumberOfTrits);
                Array.Reverse(trits);
            }
        }
    }
}
