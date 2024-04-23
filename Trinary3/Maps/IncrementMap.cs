namespace Trinary3.Maps
{
    internal class IncrementMap : ITrio<Trit>
    {
        public Trit this[Trit index] => index == Trit.Positive ? Trit.Positive : index + 1;
    }

}
