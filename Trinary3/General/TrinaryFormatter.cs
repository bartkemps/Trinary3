namespace Trinary3.General
{
    using System;
    using System.Numerics;
    using System.Text;
    using Trinary3;

    /// <summary>
    /// Provides functionality to format trinary numbers.
    /// </summary>
    internal class TrinaryFormatter
    {
        private readonly TrinarySettings settings;

        /// <summary>
        /// Initializes a new instance of the TrinaryFormatter class.
        /// </summary>
        /// <param name="settings">The settings for trinary formatting.</param>
        public TrinaryFormatter(TrinarySettings settings)
        {
            this.settings = settings ?? new TrinarySettings();
        }

        /// <summary>
        /// Converts a BigInteger into an array of trits.
        /// </summary>
        /// <param name="value">The BigInteger value.</param>
        /// <returns>An array of trits.</returns>
        public static Trit[] ToTrits(BigInteger value)
        {
            if (value == 0) return new Trit[] { Trit.Zero };
            int estimatedSize = value == 0 ? 1 : 1 + (int)Math.Ceiling(BigInteger.Log(BigInteger.Abs(value), 3));
            var result = new Trit[estimatedSize];
            int index = 0;
            while (value != 0)
            {
                var remainder = (int)(value >= 2 ? (value - 2) % 3 - 1 : (value - 1) % 3 + 1);
                value -= remainder;
                value /= 3;
                result[index++] = (Trit)remainder;
            }
            Array.Resize(ref result, index);
            Array.Reverse(result);
            return result;
        }

        private static readonly Trit[] minValue = new[] { Trit.Negative, Trit.Positive, Trit.Negative, Trit.Positive, Trit.Negative, Trit.Negative, Trit.Negative, Trit.Zero, Trit.Zero, Trit.Negative, Trit.Negative, Trit.Negative, Trit.Zero, Trit.Zero, Trit.Positive, Trit.Negative, Trit.Zero, Trit.Negative, Trit.Positive, Trit.Positive, Trit.Negative, Trit.Negative, Trit.Positive, Trit.Zero, Trit.Negative, Trit.Zero, Trit.Negative, Trit.Zero, Trit.Positive, Trit.Zero, Trit.Positive, Trit.Zero, Trit.Negative, Trit.Negative, Trit.Positive, Trit.Zero, Trit.Positive, Trit.Negative, Trit.Zero, Trit.Zero, Trit.Positive };


        /// <summary>
        /// Converts an Int64 into an array of trits.
        /// </summary>
        /// <param name="value">The Int64 value.</param>
        /// <returns>An array of trits.</returns>
        public static Trit[] ToTrits(long value)
        {
            if (value == 0) return new Trit[] { Trit.Zero };
            if (value == long.MinValue) return minValue;
            var result = new Trit[41]; // Maximum size for a long value
            int index = 0;

            while (value != 0)
            {
                // Funky balanced remainder that also works for long.MinValue and long.MaxValue
                var remainder = (int)(value > 1 ? (value - 2) % 3 - 1 : value >= -1 ? value : (value + 2) % 3 + 1);
                value -= remainder;
                value /= 3;
                result[index++] = (Trit)remainder;
            }
            Array.Resize(ref result, index);
            Array.Reverse(result);
            return result;
        }

        /// <summary>
        /// Converts a BigInteger into a trinary string.
        /// </summary>
        /// <param name="value">The BigInteger value.</param>
        /// <returns>The trinary string.</returns>
        public string ToString(BigInteger value)
        {
            var trits = ToTrits(value);
            return ToString(trits);
        }

        /// <summary>
        /// Converts an Int64 into a trinary string.
        /// </summary>
        /// <param name="value">The BigInteger value.</param>
        /// <returns>The trinary string.</returns>
        public string ToString(long value)
        {
            var trits = ToTrits(value);
            return ToString(trits);
        }

        /// <summary>
        /// Converts an array of trits into a trinary string.
        /// </summary>
        /// <param name="trits">The array of trits.</param>
        /// <returns>The trinary string.</returns>
        private string ToString(Trit[] trits)
        {
            var sb = new StringBuilder(trits.Length);
            foreach (var trit in trits)
            {
                switch (trit)
                {
                    case Trit.Positive:
                        sb.Append(settings.Positive);
                        break;
                    case Trit.Zero:
                        sb.Append(settings.Zero);
                        break;
                    case Trit.Negative:
                        sb.Append(settings.Negative);
                        break;
                }
            }
            return sb.ToString();
        }
    }
}