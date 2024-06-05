namespace Trinary3.Maps
{
    internal abstract class LinearMap : ITrio<Trit>
    {
        public abstract Trit this[Trit index] { get; }
        public Trit Negative => this[Trit.Negative];
        public Trit Zero => this[Trit.Zero];
        public Trit Positive => this[Trit.Positive];
    }
}
