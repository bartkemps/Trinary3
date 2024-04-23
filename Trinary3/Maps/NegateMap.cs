namespace Trinary3.Maps
{
    internal class NegateMap : ITrio<Trit>
    {
        public Trit this[Trit index] => (Trit)(0 - index);
    }

}
