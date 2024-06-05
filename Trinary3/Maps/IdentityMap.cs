namespace Trinary3.Maps
{
    internal class IdentityMap : LinearMap
    {
        public override Trit this[Trit index] => index;
    }
}
