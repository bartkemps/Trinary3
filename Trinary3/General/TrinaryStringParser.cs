namespace Trinary3.General
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using Trinary3;

    internal class TrinaryStringParser
    {
        private readonly TrinarySettings settings;

        /// <summary>
        /// Settings for the parser.
        /// </summary>
        /// <param name=""></param>
        public TrinaryStringParser(TrinarySettings settings = default)
        {
            this.settings = settings ?? new TrinarySettings();
        }

        /// <summary>
        /// Parses a trinary string into a BigInteger.
        /// </summary>
        /// <param name="value">The string containing the trinary value</param>
        /// <returns>The BigInteger containing the valuse</returns>
        public BigInteger ParseBigInteger(string value)
        {
            var trits = ParseTrits(value);
            return trits.ToBigInteger();
        }

        /// <summary>
        /// Parses a trinary string into a BigInteger.
        /// </summary>
        /// <param name="value">The string containing the trinary value</param>
        /// <returns>The BigInteger containing the value</returns>
        /// <exception cref="FormatException">Thrown when the input string contains an unrecognized character and IgnoreUnrecognizedCharacters is false.</exception>
        /// <exception cref="OverflowException">Thrown when the trinary number is too large to fit in a long.</exception>
        public long ParseInt64(string value)
        {
            var trits = ParseTrits(value);
            return trits.ToInt64();
        }

        /// <summary>
        /// Parses a trinary string into an array of trits.
        /// </summary>
        /// <param name="value">The string containing the trinary value</param>
        /// <returns>The array containing the trits</returns>
        /// <exception cref="FormatException"></exception>
        public Trit[] ParseTrits(string value)
        {
            var result = new List<Trit>();
            foreach(char c in value)
            {
                if (settings.IgnoreWhitespace && char.IsWhiteSpace(c))
                {
                    continue;
                }
                if (c == settings.Positive)
                {
                    result.Add(Trit.Positive);
                }
                else if (c == settings.Negative)
                {
                    result.Add(Trit.Negative);
                }
                else if (c == settings.Zero)
                {
                    result.Add(Trit.Zero);
                }
                else if (!settings.IgnoreUnrecognizedCharacters)
                {
                    throw new FormatException($"Unrecognized character '{c}'.");
                }
            }
            return result.ToArray();
        }
    }
}