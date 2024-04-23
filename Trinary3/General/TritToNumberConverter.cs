namespace Trinary3.General
{
    using System.Numerics;
    using System.Runtime.InteropServices.ComTypes;

    internal static class TritToNumberConverter
    {
        /// <summary>
        /// Parses an array containg trits into a BigInteger.
        /// </summary>
        /// <param name="value">The array containing the trits</param>
        /// <returns>The BigInteger containing the valuse</returns>
        public static BigInteger ToBigInteger(this Trit[] value)
        {
            var result = new BigInteger(0);
            var factor = new BigInteger(1);
            for (var i = value.Length - 1; i >= 0; i--)
            {
                result += factor * (sbyte)value[i];
                factor *= 3;
            }
            return result;
        }

        /// <summary>
        /// Parses an array containg trits into an Int64.
        /// </summary>
        /// <param name="value">The array containing the trits</param>
        /// <returns>The BigInteger containing the valuse</returns>
        public static long ToInt64(this Trit[] value)
        {
            var tritsLeft = value.Length;
            const int doubleTritShiftFactor = 9;

            if (tritsLeft == 0) return 0;
            if (tritsLeft == 1) return (long)value[0];
            checked
            {
                var result = PopNextTritpairValue();
                var factor = 1L;
                while (tritsLeft >= 2)
                {
                    factor *= doubleTritShiftFactor;
                    // Add the value of the current pair of digits to the result
                    result += factor * PopNextTritpairValue();
                }
                // If there's one digit left, process it separately
                if (tritsLeft == 1) 
                {
                    // Don't multiply the factor by nine yet:
                    // The left most trit is the most significant one and may have a value outside the allowed range
                    // for an Int64.
                    // This is a side effect of balanced ternary: as digits can be both positive and negative, the
                    // total value can be valid even if the most significant digit is outside the valid range.
                    var oneNinthOfTheLastTritsValue = factor * (long)value[0];

                    // We need tho add the value nine times.
                    // WARNING: DO NOT REPLACE BY 9 * oneNinthOfTheLastTritsValue
                    // This would cause an overflow exception if the trit value is the maximum value for a trit.
                    return result + 4 * oneNinthOfTheLastTritsValue + 5 * oneNinthOfTheLastTritsValue;
                }
                return result;
            }
            long PopNextTritpairValue() => (long)value[--tritsLeft] + 3 * (long)value[--tritsLeft];
        }
    }
}