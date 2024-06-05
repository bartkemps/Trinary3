namespace Trinary3.Maps
{
    internal class MaxZeroMap : LinearMap
    {
        public override Trit this[Trit index] => index == Trit.Negative ? Trit.Negative : Trit.Zero;
    }
}
