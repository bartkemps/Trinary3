namespace Trinary3.Maps
{
    internal class IsNegativeMap : ITrio<Trit>
    {
        public Trit this[Trit index] => index == Trit.Negative ? Trit.Positive : Trit.Negative;
    }

}
