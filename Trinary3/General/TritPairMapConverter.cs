namespace Trinary3.General
{
    using System;

    internal static class TritPairMapConverter
    {
        /// <summary>
        /// Interprets the integer as a nine trit value and uses them to create a TritPairMap.
        /// </summary>
        public static TritPairMap<Trit> CreateTritPairMap(int value)
        {
            if (value < -9841 || value > 9841)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "The value must be between -9841 and 9841.");
            }
            var trits = TrinaryFormatter.ToTrits(value);
            Array.Reverse(trits);
            Array.Resize(ref trits, 9);
            Array.Reverse(trits);
            return CreateTritPairMap(trits);
        }

        public static TritPairMap<Trit> CreateTritPairMap(Trit[] trits)
        {
            if (trits == null || trits.Length > 9)
            {
                throw new ArgumentException("The trits array must contain exactly nine trits.", nameof(trits));
            }

            return new TritPairMap<Trit>(
                trits[0], trits[1], trits[2],
                trits[3], trits[4], trits[5],
                trits[6], trits[7], trits[8]);
        }

        public static short ToInt16(INono<Trit> tritPairMap)
        {
            var trits = new []
            {
                tritPairMap[Trit.Negative, Trit.Negative]
                , tritPairMap[Trit.Negative, Trit.Zero]
                , tritPairMap[Trit.Negative, Trit.Positive]
                , tritPairMap[Trit.Zero, Trit.Negative]
                , tritPairMap[Trit.Zero, Trit.Zero]
                , tritPairMap[Trit.Zero, Trit.Positive]
                , tritPairMap[Trit.Positive, Trit.Negative]
                , tritPairMap[Trit.Positive, Trit.Zero]
                , tritPairMap[Trit.Positive, Trit.Positive]
            };

            return (short)TritToNumberConverter.ToInt64(trits);
        }
    }
}
