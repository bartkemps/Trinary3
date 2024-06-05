namespace Trinary3.Maps
{
    internal class NegateMap : LinearMap
    {
        public override Trit this[Trit index] => (Trit)(0 - index);
    }

}
