using System.Numerics;
using Trinary3.General;

namespace Trinary3
{
    public static partial class TrinaryNumber
    {
        /// <summary>
        /// Formats a BigInteger value as a trinary string.
        /// </summary>
        /// <param name="value">The BigInteger value.</param>
        /// <param name="settings">The settings for trinary formatting.</param>
        /// <returns>The trinary string.</returns>
        public static string Format(BigInteger value, TrinarySettings settings = null)
        {
            var formatter = new TrinaryFormatter(settings);
            return formatter.ToString(value);
        }

        /// <summary>
        /// Formats a long value as a trinary string.
        /// </summary>
        /// <param name="value">The long value.</param>
        /// <param name="settings">The settings for trinary formatting.</param>
        /// <returns>The trinary string.</returns>
        public static string Format(long value, TrinarySettings settings = null)
        {
            var formatter = new TrinaryFormatter(settings);
            return formatter.ToString(value);
        }

        /// <summary>
        /// Formats an int value as a trinary string.
        /// </summary>
        /// <param name="value">The int value.</param>
        /// <param name="settings">The settings for trinary formatting.</param>
        /// <returns>The trinary string.</returns>
        public static string Format(int value, TrinarySettings settings = null)
        {
            var formatter = new TrinaryFormatter(settings);
            return formatter.ToString(value);
        }

        /// <summary>
        /// Formats a short value as a trinary string.
        /// </summary>
        /// <param name="value">The short value.</param>
        /// <param name="settings">The settings for trinary formatting.</param>
        /// <returns>The trinary string.</returns>
        public static string Format(short value, TrinarySettings settings = null)
        {
            var formatter = new TrinaryFormatter(settings);
            return formatter.ToString(value);
        }

        /// <summary>
        /// Formats a sbyte value as a trinary string.
        /// </summary>
        /// <param name="value">The sbyte value.</param>
        /// <param name="settings">The settings for trinary formatting.</param>
        /// <returns>The trinary string.</returns>
        public static string Format(sbyte value, TrinarySettings settings = null)
        {
            var formatter = new TrinaryFormatter(settings);
            return formatter.ToString(value);
        }

        /// <summary>
        /// Formats a <see cref="IntT3"/> value as a trinary string.
        /// </summary>
        /// <param name="value">The sbyte value.</param>
        /// <param name="settings">The settings for trinary formatting.</param>
        /// <returns>The trinary string.</returns>
        public static string Format(IntT3 value, TrinarySettings settings = null)
        {
            var formatter = new TrinaryFormatter(settings);
            return formatter.ToString((long)value);
        }
    }
}
