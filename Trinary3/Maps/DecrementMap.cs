namespace Trinary3.Maps
{
    internal class DecrementMap : ITrio<Trit>
    {
        public Trit this[Trit index] => index == Trit.Negative ? Trit.Negative : index - 1;
    }

}
