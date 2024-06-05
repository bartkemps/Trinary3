namespace Trinary3.Maps
{
    internal class CircularIncrementMap : LinearMap
    {
        public override Trit this[Trit index] => index == Trit.Positive ? Trit.Negative : index + 1;
    }
}
