namespace Trinary3
{
    using System.Diagnostics;

    /// <summary>
    /// Maps the nine posibillities of a pair of trits to a value.
    /// </summary>
    public interface INono<TItem> : ITrio<ITrio<TItem>>
    {
        TItem this[Trit row, Trit column] { get; }
    }
}
