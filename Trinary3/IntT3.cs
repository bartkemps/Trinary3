using System;

/// <summary>
/// Represents a number between -13 and 13.
/// </summary>
public struct IntT3 : IComparable<IntT3>, IEquatable<IntT3>, IFormattable, IConvertible, ITrinaryNumber
{
    /// <summary>
    /// The underlying value of the IntT3.
    /// </summary>
    private readonly sbyte value;

    /// <summary>
    /// Initializes a new instance of the IntT3 struct.
    /// </summary>
    /// <param name="value">The value of the IntT3.</param>
    private IntT3(sbyte value)
    {
        if (value < MinValue || value > MaxValue)
        {
            // trigger overflow in checked context
            value += sbyte.MinValue;
            value += sbyte.MinValue;
        }
        value%=Range;
        if (value < MinValue) value += Range;
        else if (value > MaxValue) value -= Range;
        this.value = value;
    }

    /// <summary>
    /// Compares this instance to a specified IntT3 and returns an indication of their relative values.
    /// </summary>
    /// <param name="other">A IntT3 to compare with this instance.</param>
    /// <returns>A signed number indicating the relative values of this instance and value.</returns>
    public int CompareTo(IntT3 other) => value.CompareTo(other.value);

    /// <summary>
    /// Returns a value indicating whether this instance is equal to a specified IntT3.
    /// </summary>
    /// <param name="other">A IntT3 to compare to this instance.</param>
    /// <returns>true if value has the same value as this instance; otherwise, false.</returns>
    public bool Equals(IntT3 other) => value == other.value;

    /// <summary>
    /// Returns a value indicating whether this instance is equal to a specified object.
    /// </summary>
    /// <param name="obj">An object to compare to this instance.</param>
    /// <returns>true if value is an instance of IntT3 and equals the value of this instance; otherwise, false.</returns>
    public override bool Equals(object obj) => obj is IntT3 IntT3 && Equals(IntT3);

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    /// <returns>A 32-bit signed integer hash code.</returns>
    public override int GetHashCode() => value.GetHashCode();

    /// <summary>
    /// Determines whether two specified IntT3s have the same value.
    /// </summary>
    /// <param name="left">The first IntT3 to compare.</param>
    /// <param name="right">The second IntT3 to compare.</param>
    /// <returns>true if the value of left is the same as the value of right; otherwise, false.</returns>
    public static bool operator ==(IntT3 left, IntT3 right) => left.Equals(right);

    /// <summary>
    /// Determines whether two specified IntT3s have different values.
    /// </summary>
    /// <param name="left">The first IntT3 to compare.</param>
    /// <param name="right">The second IntT3 to compare.</param>
    /// <returns>true if the value of left is different from the value of right; otherwise, false.</returns>
    public static bool operator !=(IntT3 left, IntT3 right) => !(left == right);

    /// <summary>
    /// Converts the sbyte value to a IntT3.
    /// </summary>
    /// <param name="value">The sbyte value.</param>
    public static explicit operator IntT3(sbyte value) => new IntT3(value);

    /// <summary>
    /// Converts the IntT3 to a sbyte value.
    /// </summary>
    /// <param name="IntT3">The IntT3.</param>
    public static explicit operator sbyte(IntT3 IntT3) => IntT3.value;


    /// <summary>
    /// Returns a string that represents the current IntT3.
    /// </summary>
    /// <returns>A string that represents the current IntT3.</returns>
    public override string ToString() => value.ToString();

    /// <summary>
    /// Returns a string that represents the current IntT3, formatted according to the specified format.
    /// </summary>
    /// <param name="format">The format to use.</param>
    /// <returns>A string that represents the current IntT3, formatted according to the specified format.</returns>
    public string ToString(string format) => value.ToString(format);

    /// <summary>
    /// Returns a string that represents the current IntT3, formatted according to the specified format provider.
    /// </summary>
    /// <param name="provider">The format provider to use.</param>
    /// <returns>A string that represents the current IntT3, formatted according to the specified format provider.</returns>
    public string ToString(IFormatProvider provider) => value.ToString(provider);

    /// <summary>
    /// Returns a string that represents the current IntT3, formatted according to the specified format and format provider.
    /// </summary>
    /// <param name="format">The format to use.</param>
    /// <param name="provider">The format provider to use.</param>
    /// <returns>A string that represents the current IntT3, formatted according to the specified format and format provider.</returns>
    public string ToString(string format, IFormatProvider provider) => value.ToString(format, provider);

    /// <summary>
    /// Increments the IntT3 by 1.
    /// </summary>
    /// <param name="a">The IntT3 to increment.</param>
    /// <returns>The incremented IntT3.</returns>
    public static IntT3 operator ++(IntT3 a)
    {
        int newValue = a.value + 1;
        if (newValue > 13) newValue = newValue - int.MinValue + int.MaxValue + IntT3.MinValue - IntT3.MaxValue;
        return new IntT3((sbyte)newValue);
    }

    /// <summary>
    /// Decrements the IntT3 by 1.
    /// </summary>
    /// <param name="a">The IntT3 to decrement.</param>
    /// <returns>The decremented IntT3.</returns>
    public static IntT3 operator --(IntT3 a)
    {
        int newValue = a.value - 1;
        if (newValue < MinValue) newValue = newValue - int.MinValue + int.MaxValue + IntT3.MaxValue - IntT3.MinValue;
        return new IntT3((sbyte)newValue);
    }
    /// <summary>
    /// Returns the negation of a specified IntT3.
    /// </summary>
    /// <param name="a">The IntT3 to negate.</param>
    /// <returns>The negation of the IntT3.</returns>
    public static IntT3 operator -(IntT3 a) => new IntT3((sbyte)-a.value);

    /// <summary>
    /// Returns the value of the specified IntT3.
    /// </summary>
    /// <param name="a">The IntT3 to return.</param>
    /// <returns>The value of the IntT3.</returns>
    public static IntT3 operator +(IntT3 a) => a;

    /// <summary>
    /// Returns a value indicating whether a specified IntT3 is less than another specified IntT3.
    /// </summary>
    /// <param name="left">The first IntT3 to compare.</param>
    /// <param name="right">The second IntT3 to compare.</param>
    /// <returns>true if left is less than right; otherwise, false.</returns>
    public static bool operator <(IntT3 left, IntT3 right) => left.CompareTo(right) < 0;

    /// <summary>
    /// Returns a value indicating whether a specified IntT3 is less than or equal to another specified IntT3.
    /// </summary>
    /// <param name="left">The first IntT3 to compare.</param>
    /// <param name="right">The second IntT3 to compare.</param>
    /// <returns>true if left is less than or equal to right; otherwise, false.</returns>
    public static bool operator <=(IntT3 left, IntT3 right) => left.CompareTo(right) <= 0;

    /// <summary>
    /// Returns a value indicating whether a specified IntT3 is greater than another specified IntT3.
    /// </summary>
    /// <param name="left">The first IntT3 to compare.</param>
    /// <param name="right">The second IntT3 to compare.</param>
    /// <returns>true if left is greater than right; otherwise, false.</returns>
    public static bool operator >(IntT3 left, IntT3 right) => left.CompareTo(right) > 0;

    /// <summary>
    /// Returns a value indicating whether a specified IntT3 is greater than or equal to another specified IntT3.
    /// </summary>
    /// <param name="left">The first IntT3 to compare.</param>
    /// <param name="right">The second IntT3 to compare.</param>
    /// <returns>true if left is greater than or equal to right; otherwise, false.</returns>
    public static bool operator >=(IntT3 left, IntT3 right) => left.CompareTo(right) >= 0;

    /// <summary>
    /// Subtracts an IntT3 from another IntT3 and returns the result.
    /// </summary>
    /// <param name="a">The minuend.</param>
    /// <param name="b">The subtrahend.</param>
    /// <returns>The result of subtracting b from a.</returns>
    public static int operator -(IntT3 a, IntT3 b) => a.value - b.value;

    /// <summary>
    /// Adds two IntT3 values and returns the result.
    /// </summary>
    /// <param name="a">The first value to add.</param>
    /// <param name="b">The second value to add.</param>
    /// <returns>The result of adding a and b.</returns>
    public static int operator +(IntT3 a, IntT3 b) => a.value + b.value;

    /// <summary>
    /// Divides an IntT3 by another IntT3 and returns the result.
    /// </summary>
    /// <param name="a">The dividend.</param>
    /// <param name="b">The divisor.</param>
    /// <returns>The result of dividing a by b.</returns>
    public static int operator /(IntT3 a, IntT3 b) => a.value / b.value;

    /// <summary>
    /// Multiplies two IntT3 values and returns the result.
    /// </summary>
    /// <param name="a">The first value to multiply.</param>
    /// <param name="b">The second value to multiply.</param>
    /// <returns>The result of multiplying a and b.</returns>
    public static int operator *(IntT3 a, IntT3 b) => a.value * b.value;

    /// <summary>
    /// Returns the TypeCode for this instance.
    /// </summary>
    /// <returns>The enumerated constant that is the TypeCode of the class or value type that implements this interface.</returns>
    public TypeCode GetTypeCode() => TypeCode.Object;

    /// <summary>
    /// Converts the value of this instance to a Boolean using the specified culture-specific formatting information.
    /// </summary>
    /// <param name="provider">An IFormatProvider interface implementation that supplies culture-specific formatting information.</param>
    /// <returns>A Boolean equivalent of the value of this instance.</returns>
    public bool ToBoolean(IFormatProvider provider) => Convert.ToBoolean(value);

    /// <summary>
    /// Converts the value of this instance to a Byte using the specified culture-specific formatting information.
    /// </summary>
    /// <param name="provider">An IFormatProvider interface implementation that supplies culture-specific formatting information.</param>
    /// <returns>A Byte equivalent of the value of this instance.</returns>
    public byte ToByte(IFormatProvider provider) => Convert.ToByte(value);

    /// <summary>
    /// Converts the value of this instance to a Char using the specified culture-specific formatting information.
    /// </summary>
    /// <param name="provider">An IFormatProvider interface implementation that supplies culture-specific formatting information.</param>
    /// <returns>A Char equivalent of the value of this instance.</returns>
    public char ToChar(IFormatProvider provider) => Convert.ToChar(value);

    /// <summary>
    /// Converts the value of this instance to a DateTime using the specified culture-specific formatting information.
    /// </summary>
    /// <param name="provider">An IFormatProvider interface implementation that supplies culture-specific formatting information.</param>
    /// <returns>A DateTime equivalent of the value of this instance.</returns>
    public DateTime ToDateTime(IFormatProvider provider) => throw new InvalidCastException("Cannot convert IntT3 to DateTime.");

    /// <summary>
    /// Converts the value of this instance to a Decimal using the specified culture-specific formatting information.
    /// </summary>
    /// <param name="provider">An IFormatProvider interface implementation that supplies culture-specific formatting information.</param>
    /// <returns>A Decimal equivalent of the value of this instance.</returns>
    public decimal ToDecimal(IFormatProvider provider) => value;

    /// <summary>
    /// Converts the value of this instance to a Double using the specified culture-specific formatting information.
    /// </summary>
    /// <param name="provider">An IFormatProvider interface implementation that supplies culture-specific formatting information.</param>
    /// <returns>A Double equivalent of the value of this instance.</returns>
    public double ToDouble(IFormatProvider provider) => value;

    /// <summary>
    /// Converts the value of this instance to a Int16 using the specified culture-specific formatting information.
    /// </summary>
    /// <param name="provider">An IFormatProvider interface implementation that supplies culture-specific formatting information.</param>
    /// <returns>A Int16 equivalent of the value of this instance.</returns>
    public short ToInt16(IFormatProvider provider) => value;

    /// <summary>
    /// Converts the value of this instance to a Int32 using the specified culture-specific formatting information.
    /// </summary>
    /// <param name="provider">An IFormatProvider interface implementation that supplies culture-specific formatting information.</param>
    /// <returns>A Int32 equivalent of the value of this instance.</returns>
    public int ToInt32(IFormatProvider provider) => value;

    /// <summary>
    /// Converts the value of this instance to a Int64 using the specified culture-specific formatting information.
    /// </summary>
    /// <param name="provider">An IFormatProvider interface implementation that supplies culture-specific formatting information.</param>
    /// <returns>A Int64 equivalent of the value of this instance.</returns>
    public long ToInt64(IFormatProvider provider) => value;

    /// <summary>
    /// Converts the value of this instance to a SByte using the specified culture-specific formatting information.
    /// </summary>
    /// <param name="provider">An IFormatProvider interface implementation that supplies culture-specific formatting information.</param>
    /// <returns>A SByte equivalent of the value of this instance.</returns>
    public sbyte ToSByte(IFormatProvider provider) => value;

    /// <summary>
    /// Converts the value of this instance to a Single using the specified culture-specific formatting information.
    /// </summary>
    /// <param name="provider">An IFormatProvider interface implementation that supplies culture-specific formatting information.</param>
    /// <returns>A Single equivalent of the value of this instance.</returns>
    public float ToSingle(IFormatProvider provider) => value;

    /// <summary>
    /// Converts the value of this instance to an Object of the specified Type that has an equivalent value, using the specified culture-specific formatting information.
    /// </summary>
    /// <param name="conversionType">The Type into which to convert this instance.</param>
    /// <param name="provider">An IFormatProvider interface implementation that supplies culture-specific formatting information.</param>
    /// <returns>An Object instance of type conversionType whose value is equivalent to the value of this instance.</returns>
    public object ToType(Type conversionType, IFormatProvider provider) => Convert.ChangeType(value, conversionType, provider);

    /// <summary>
    /// Converts the value of this instance to a UInt16 using the specified culture-specific formatting information.
    /// </summary>
    /// <param name="provider">An IFormatProvider interface implementation that supplies culture-specific formatting information.</param>
    /// <returns>A UInt16 equivalent of the value of this instance.</returns>
    public ushort ToUInt16(IFormatProvider provider) => Convert.ToUInt16(value);

    /// <summary>
    /// Converts the value of this instance to a UInt32 using the specified culture-specific formatting information.
    /// </summary>
    /// <param name="provider">An IFormatProvider interface implementation that supplies culture-specific formatting information.</param>
    /// <returns>A UInt32 equivalent of the value of this instance.</returns>
    public uint ToUInt32(IFormatProvider provider) => Convert.ToUInt32(value);

    /// <summary>
    /// Converts the value of this instance to a UInt64 using the specified culture-specific formatting information.
    /// </summary>
    /// <param name="provider">An IFormatProvider interface implementation that supplies culture-specific formatting information.</param>
    /// <returns>A UInt64 equivalent of the value of this instance.</returns>
    public ulong ToUInt64(IFormatProvider provider) => Convert.ToUInt64(value);
    
    /// <summary>
    /// Represents the smallest possible value of a IntT3. This field is constant.
    /// </summary>
    public const int MinValue = -13;

    /// <summary>
    /// Represents the largest possible value of a IntT3. This field is constant.
    /// </summary>
    public const int MaxValue = 13;

    public const int Range = MaxValue - MinValue + 1;
}