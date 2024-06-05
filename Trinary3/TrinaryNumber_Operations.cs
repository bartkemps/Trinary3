namespace Trinary3
{
    using System;
    using System.Numerics;
    using Trinary3.General;
    using Trinary3.Maps;

    public static partial  class TrinaryNumber
    {
        /// <summary>
        /// This map does not change the trit.
        /// </summary>
        public static ITrio<Trit> IdentityLinearMap => new IdentityMap();
        /// <summary>
        /// This map negates the trit: is set to Negative if Positive, Positive if Negative, and Zero if Zero.
        /// </summary>
        public static ITrio<Trit> NegateLinearMap => new NegateMap();
        /// <summary>
        /// This map sets the trit to Positive if it has a non-zero value, and Negative otherwise.
        /// </summary>
        public static ITrio<Trit> HasValueLinearMap => new HasValueMap();
        /// <summary>
        /// This map sets the trit to Positive if it has a negative value, and Negative otherwise.
        /// </summary>
        public static ITrio<Trit> IsNegativeLinearMap => new IsNegativeMap();
        /// <summary>
        /// This map sets the trit to Positive if it has a zero value, and Negative otherwise.
        /// </summary>
        public static ITrio<Trit> IsZeroLinearMap => new IsNegativeMap();
        /// <summary>
        /// This map sets the trit to Positive if it has a positive value, and Negative otherwise.
        /// </summary>
        public static ITrio<Trit> IsPositiveLinearMap => new IsPositiveMap();
        /// <summary>
        /// This map increases the trit by one.
        /// It does not wrap around: if the input trit is Positive, the output is too.
        /// </summary>
        public static ITrio<Trit> IncrementLinearMap => new IncrementMap();
        /// <summary>
        /// This map decreases the trit by one.
        /// It does not wrap around: if the input trit is Negative, the output is too.
        /// </summary>
        public static ITrio<Trit> DecrementLinearMap => new DecrementMap();
        /// <summary>
        /// This map increases the trit by one.
        /// It wraps around: if the input trit is Positive, the output is Negative.
        public static ITrio<Trit> CircularIncrementLinearMap => new CircularIncrementMap();
        /// <summary>
        /// This map decreases the trit by one.
        /// It wraps around: if the input trit is Negative, the output is Positive.
        /// </summary>
        public static ITrio<Trit> CircularDecrementLinearMap => new CircularDecrementMap();
        /// <summary>
        /// This map maximizes the trit to Zero. So if the input trit is Negative, the output is Negative, otherwise Zero.
        /// </summary>
        public static ITrio<Trit> MaxZeroLinearMap => new MaxZeroMap();
        /// <summary>
        /// This map minimizes the trit to Zero. So if the input trit is Positive, the output is Positive, otherwise Zero.
        /// </summary>
        public static ITrio<Trit> MinZeroLinearMap => new MinZeroMap();

        /// <summary>
        /// Performs a tritwise operation on a number.
        /// </summary>
        /// <param name="value">The number to perform the tritwise operation on</param>
        /// <param name="map">
        /// The operation to perform, expressed in a trio of trit output values, 
        /// to be returned when the input trit is Negative, Zero, or Positive, respectively.
        /// </param>
        /// <param name="minNumberOfTrits">
        /// The minimum number of trits the result should have.
        /// When a zero input trit maps to a non-zero output trit, 
        /// the resulting number will be dependent on the number of trits.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static BigInteger TritwiseMap(BigInteger value, ITrio<Trit> map, int minNumberOfTrits = 0)
        {
            if (minNumberOfTrits < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minNumberOfTrits), minNumberOfTrits, "The minimum number of trits must be non-negative.");
            }
            var trits = TrinaryFormatter.ToTrits(value);
            if (trits.Length < minNumberOfTrits)
            {
                Array.Reverse(trits);
                Array.Resize(ref trits, minNumberOfTrits);
                Array.Reverse(trits);
            }
            for(int i = 0; i < trits.Length; i++)
            {
                trits[i] = map[trits[i]];
            }
            return TritToNumberConverter.ToBigInteger(trits);
        }

        /// <summary>
        /// Performs a tritwise operation on a number.
        /// </summary>
        /// <param name="value">The number to perform the tritwise operation on</param>
        /// <param name="map">
        /// The operation to perform, expressed in a trio of trit output values, 
        /// to be returned when the input trit is Negative, Zero, or Positive, respectively.
        /// </param>
        /// <param name="minNumberOfTrits">
        /// The minimum number of trits the result should have.
        /// When a zero input trit maps to a non-zero output trit, 
        /// the resulting number will be dependent on the number of trits.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static long TritwiseMap(long value, ITrio<Trit> map, int minNumberOfTrits = 0)
        {
            if (minNumberOfTrits < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minNumberOfTrits), minNumberOfTrits, "The minimum number of trits must be non-negative.");
            }
            var trits = TrinaryFormatter.ToTrits(value);
            SetMinimumNumberOfTrits(minNumberOfTrits, ref trits);
            for (int i = 0; i < trits.Length; i++)
            {
                trits[i] = map[trits[i]];
            }
            return TritToNumberConverter.ToInt64(trits);
        }

        /// <summary>
        /// Performs a tritwise operation on a pair of numbers number.
        /// </summary>
        /// <param name="value1">The first number to perform the tritwise operation on</param>
        /// <param name="value2">The second number to perform the tritwise operation on</param>
        /// <param name="map">
        /// The operation to perform, expressed in a nono (a trio of trios) of trit output values, 
        /// to be returned when the input trits is Negative - Negative through Positive - Positive, respectively.
        /// </param>
        /// <param name="minNumberOfTrits">
        /// The minimum number of trits the result should have.
        /// When a pair of zero input trits map to a non-zero output trit, 
        /// the resulting number will be dependent on the number of trits.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private static void SetMinimumNumberOfTrits(int minNumberOfTrits, ref Trit[] trits)
        {
            if (trits.Length < minNumberOfTrits)
            {
                Array.Reverse(trits);
                Array.Resize(ref trits, minNumberOfTrits);
                Array.Reverse(trits);
            }
        }

        /// <summary>
        /// Performs a tritwise operation on a pair of numbers number.
        /// </summary>
        /// <param name="value1">The first number to perform the tritwise operation on</param>
        /// <param name="value2">The second number to perform the tritwise operation on</param>
        /// <param name="map">
        /// The operation to perform, expressed in a nono (a trio of trios) of trit output values, 
        /// to be returned when the input trits is Negative - Negative through Positive - Positive, respectively.
        /// </param>
        /// <param name="minNumberOfTrits">
        /// The minimum number of trits the result should have.
        /// When a pair of zero input trits map to a non-zero output trit, 
        /// the resulting number will be dependent on the number of trits.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static BigInteger TritwiseMap(BigInteger value1, BigInteger value2, ITrio<ITrio<Trit>> map, int minNumberOfTrits = 0)
        {
            if (minNumberOfTrits < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minNumberOfTrits), minNumberOfTrits, "The minimum number of trits must be non-negative.");
            }
            var trits1 = TrinaryFormatter.ToTrits(value1);
            var trits2 = TrinaryFormatter.ToTrits(value2);
            minNumberOfTrits = Math.Max(minNumberOfTrits, Math.Max(trits1.Length, trits2.Length));
            SetMinimumNumberOfTrits(minNumberOfTrits, ref trits1);
            SetMinimumNumberOfTrits(minNumberOfTrits, ref trits2);
            for (int i = 0; i < trits1.Length; i++)
            {
                trits1[i] = map[trits1[i]][trits2[i]];
            }
            return TritToNumberConverter.ToBigInteger(trits1);
        }

        public static long TritwiseMap(long value1, long value2, ITrio<ITrio<Trit>> map, int minNumberOfTrits = 0)
        {
            if (minNumberOfTrits < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minNumberOfTrits), minNumberOfTrits, "The minimum number of trits must be non-negative.");
            }
            var trits1 = TrinaryFormatter.ToTrits(value1);
            var trits2 = TrinaryFormatter.ToTrits(value2);
            minNumberOfTrits = Math.Max(minNumberOfTrits, Math.Max(trits1.Length, trits2.Length));
            SetMinimumNumberOfTrits(minNumberOfTrits, ref trits1);
            SetMinimumNumberOfTrits(minNumberOfTrits, ref trits2);
            for (int i = 0; i < trits1.Length; i++)
            {
                trits1[i] = map[trits1[i]][trits2[i]];
            }
            return TritToNumberConverter.ToInt64(trits1);
        }


    }
}
