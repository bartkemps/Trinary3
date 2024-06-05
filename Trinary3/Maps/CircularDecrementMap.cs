namespace Trinary3.Maps
{
    internal class CircularDecrementMap : LinearMap
    {
        public override Trit this[Trit index] => index == Trit.Negative ? Trit.Positive : index - 1;
    }
}
