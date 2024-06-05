namespace Trinary3.Maps
{
    internal class MinZeroMap : LinearMap
    {
        public override Trit this[Trit index] => index == Trit.Positive ? Trit.Positive : Trit.Zero;
    }
}
