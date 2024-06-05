namespace Trinary3.Maps
{
    internal class IsPositiveMap : LinearMap
    {
        public override Trit this[Trit index] => index == Trit.Positive ? Trit.Positive : Trit.Negative;
    }
}
