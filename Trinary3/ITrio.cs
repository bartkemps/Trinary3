namespace Trinary3
{
    /// <summary>
    /// Maps the three posibillities of a trit to a value.
    /// </summary>
    public interface ITrio<TItem>
    {
        TItem this[Trit index] { get; }
    }
}
