namespace Trinary3
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Maps the three possibilities of a trit to a value.
    /// </summary>
    [DebuggerDisplay("({Negative},{Zero},{Positive})")]
    public readonly struct T3<TItem> : ITrio<TItem>
    {
        public readonly TItem Negative;
        public readonly TItem Zero;
        public readonly TItem Positive;

        TItem ITrio<TItem>.Negative => Negative;
        TItem ITrio<TItem>.Zero => Zero;
        TItem ITrio<TItem>.Positive => Positive;

        /// <summary>
        /// Initializes a new instance of the <see cref="T3{TItem}"/> struct.
        /// </summary>
        /// <param name="positive">The value to assign to the Positive field, which corresponds to the least significant trit.</param>
        public T3(TItem positive = default)
        {
            Negative = default;
            Zero = default;
            Positive = positive;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T3{TItem}"/> struct.
        /// </summary>
        /// <param name="zero">The value to assign to the Zero field.</param>
        /// <param name="positive">The value to assign to the Positive field, which corresponds to the least significant trit.</param>
        public T3(TItem zero, TItem positive)
        {
            Negative = default;
            Zero = zero;
            Positive = positive;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T3{TItem}"/> struct.
        /// </summary>
        /// <param name="negative">The value to assign to the Negative field, which corresponds to the most significant trit.</param>
        /// <param name="zero">The value to assign to the Zero field.</param>
        /// <param name="positive">The value to assign to the Positive field, which corresponds to the least significant trit.</param>
        public T3(TItem negative, TItem zero, TItem positive)
        {
            Negative = negative;
            Zero = zero;
            Positive = positive;
        }

        /// <summary>
        /// Gets the value for the specified trit.
        /// </summary>
        /// <param name="index">The index</param>
        public TItem this[Trit index]
        {
            get
            {
                switch (index)
                {
                    case Trit.Negative: return Negative;
                    case Trit.Zero: return Zero;
                    case Trit.Positive: return Positive;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }

        /// <summary>
        /// Implicitly converts an array of three elements to a Trio.
        /// If the array has fewer than three elements, the least significant elements are set to their default values.
        /// If the array has more than three elements, an exception is thrown.
        /// </summary>
        public static implicit operator T3<TItem>(TItem[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            switch (array.Length)
            {
                case 3: return new T3<TItem>(array[0], array[1], array[2]);
                case 2: return new T3<TItem>(default, array[0], array[1]);
                case 1: return new T3<TItem>(default, default, array[0]);
                case 0: return new T3<TItem>();
                default: throw new ArgumentException("The array must contain a maximum of three elements.", nameof(array));
            }
        }
    }




}
