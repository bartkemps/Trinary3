namespace Trinary3.Maps
{
    internal class IncrementMap : LinearMap
    {
        public override Trit this[Trit index] => index == Trit.Positive ? Trit.Positive : index + 1;
    }
}
