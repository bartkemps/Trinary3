namespace Trinary3.Maps
{
    internal class HasValueMap : LinearMap
    {
        public override Trit this[Trit index] => index == Trit.Zero ? Trit.Negative : Trit.Positive;
    }
}
