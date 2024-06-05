namespace Trinary3.Maps
{
    internal class DecrementMap : LinearMap
    {
        public override Trit this[Trit index] => index == Trit.Negative ? Trit.Negative : index - 1;
    }
}
