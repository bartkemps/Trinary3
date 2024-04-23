namespace Trinary3.Maps
{
    internal class CircularIncrementMap : ITrio<Trit>
    {
        public Trit this[Trit index] => index == Trit.Positive ? Trit.Negative : index + 1;
    }

}
