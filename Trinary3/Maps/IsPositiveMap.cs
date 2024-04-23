namespace Trinary3.Maps
{
    internal class IsPositiveMap : ITrio<Trit>
    {
        public Trit this[Trit index] => index == Trit.Positive ? Trit.Positive : Trit.Negative;
    }

}
