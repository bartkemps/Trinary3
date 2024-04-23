namespace Trinary3.Maps
{
    internal class IdentityMap : ITrio<Trit>
    {
        public Trit this[Trit index] => index;
    }
}
