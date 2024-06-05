namespace Trinary3.Maps
{
    internal class IsNegativeMap : LinearMap
    {
        public override Trit this[Trit index] => index == Trit.Negative ? Trit.Positive : Trit.Negative;
    }
}
