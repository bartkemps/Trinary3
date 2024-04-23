namespace Trinary3
{
    public class TrinarySettings
    {
        /// <summary>
        /// The character representing a positive trit.
        /// </summary>
        public char Positive { get; set; } = '1';
        /// <summary>
        /// The character representing a negative trit.
        /// </summary>
        public char Negative { get; set; } = 'T';
        /// <summary>
        /// The character representing a zero trit.
        /// </summary>
        public char Zero { get; set; } = '0';
        /// <summary>
        /// If true, whitespace characters are ignored when parsing.
        /// </summary>
        public bool IgnoreWhitespace { get; set; } = true;
        /// <summary>
        /// If true, unrecognized characters are ignored when parsing.
        /// </summary>
        public bool IgnoreUnrecognizedCharacters { get; set; } = false;

    }
}