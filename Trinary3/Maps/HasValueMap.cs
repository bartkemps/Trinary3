namespace Trinary3.Maps
{
    internal class HasValueMap : ITrio<Trit>
    {
        public Trit this[Trit index] => index == Trit.Zero ? Trit.Negative : Trit.Positive;
    }

}
