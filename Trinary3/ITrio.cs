namespace Trinary3
{
    /// <summary>
    /// Maps the three posibillities of a trit to a value.
    /// </summary>
    public interface ITrio<TItem>
    {
        /// <summary>
        /// Gets the value for the specified trit.
        /// </summary>
        /// <param name="index">The index</param>
        TItem this[Trit index] { get; }

        /// <summary>
        /// Gets the value for the negative trit.
        /// </summary>
        TItem Negative { get; }
        /// <summary>
        /// Gets the value for the zero trit.
        /// </summary>
        TItem Zero { get; }
        /// <summary>
        /// Gets the value for the positive trit.
        /// </summary>
        TItem Positive { get; }
    }
}
