namespace Trinary3
{
    public static class Trio
    {
        /// <summary>
        /// Maps the three posibillities of a trit to a value.
        /// </summary>
        /// <param name="trio">The trio, containing values for Negative, Zero and Positive.</param>
        /// <param name="map">A map conting destination Trits for Negative, Zero and Positive.</param>
        /// <returns></returns>
        public static T3<TItem> Map<TItem>(this ITrio<TItem> trio, ITrio<Trit> map) 
            => new T3<TItem>(trio[map.Negative], trio[map.Zero], trio[map.Positive]);

        /// <summary>
        /// Maps the nine posibillities of a square trit to a value.
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="trio"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        public static T9<TItem> Map<TItem>(this ITrio<ITrio<TItem>> trio, ITrio<ITrio<Trit>> map)
        {
            return new T9<TItem>(
                Map(trio[Trit.Negative], map.Negative), 
                Map(trio[Trit.Zero], map.Zero), 
                Map(trio[Trit.Positive], map.Positive));
        }
    }
}
