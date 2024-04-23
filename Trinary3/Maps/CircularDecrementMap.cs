namespace Trinary3.Maps
{
    internal class CircularDecrementMap : ITrio<Trit>
    {
        public Trit this[Trit index] => index == Trit.Negative ? Trit.Positive : index - 1;
    }

}
