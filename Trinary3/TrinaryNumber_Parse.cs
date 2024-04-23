using System.Numerics;
using Trinary3.General;

namespace Trinary3
{
    /// <summary>
    /// Provides methods to parse ternary numbers to different types.
    /// </summary>
    public static partial class TrinaryNumber
    {
        /// <summary>
        /// Parses a ternary number to a BigInteger.
        /// </summary>
        /// <param name="value">The ternary number as a string.</param>
        /// <returns>The parsed BigInteger.</returns>
        public static BigInteger ParseToBigInteger(string value, TrinarySettings settings = null)
        {
            var parser = new TrinaryStringParser(settings);
            return parser.ParseBigInteger(value);
        }

        /// <summary>
        /// Parses a ternary number to a long.
        /// </summary>
        /// <param name="value">The ternary number as a string.</param>
        /// <returns>The parsed long.</returns>
        public static long ParseToInt64(string value, TrinarySettings settings = null)
        {
            var parser = new TrinaryStringParser(settings);
            return parser.ParseInt64(value);
        }

        /// <summary>
        /// Parses a ternary number to an int.
        /// </summary>
        /// <param name="value">The ternary number as a string.</param>
        /// <returns>The parsed int.</returns>
        public static int ParseToInt32(string value, TrinarySettings settings = null)
        {
            var parser = new TrinaryStringParser(settings);
            checked
            {
                return (int)parser.ParseInt64(value);
            }
        }

        /// <summary>
        /// Parses a ternary number to a short.
        /// </summary>
        /// <param name="value">The ternary number as a string.</param>
        /// <returns>The parsed short.</returns>
        public static int ParseToInt16(string value, TrinarySettings settings = null)
        {
            var parser = new TrinaryStringParser(settings);
            checked
            {
                return (short)parser.ParseInt64(value);
            }
        }

        /// <summary>
        /// Parses a ternary number to a sbyte.
        /// </summary>
        /// <param name="value">The ternary number as a string.</param>
        /// <returns>The parsed sbyte.</returns>
        public static int ParseToSByte(string value, TrinarySettings settings = null)
        {
            var parser = new TrinaryStringParser(settings);
            checked
            {
                return (sbyte)parser.ParseInt64(value);
            }
        }

        /// <summary>
        /// Parses a ternary number to an Int3.
        /// </summary>
        /// <param name="value">The ternary number as a string.</param>
        /// <returns>The parsed sbyte.</returns>
        public static IntT3 ParseToInt3(string value, TrinarySettings settings = null)
        {
            var parser = new TrinaryStringParser(settings);
            checked
            {
                return (IntT3)parser.ParseInt64(value);
            }
        }
    }
}
