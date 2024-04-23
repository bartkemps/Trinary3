using System.Numerics;
using System.Reflection;
using Trinary3;

public class TrinaryNumberTests_Parse
{
    [Theory]
    [InlineData("0", "0")]
    [InlineData("1", "1")]
    [InlineData("T", "-1")]
    [InlineData("1 00000 00000 00000 00000 00000 00000 00000 00000 00000 00000", "717897987691852588770249")] 
    [InlineData("T 00000 00000 00000 00000 00000 00000 00000 00000 00000 00000", "-717897987691852588770249")]
    [InlineData("1T1T1110011100T101TT11T01010T0T011T0T10T1", "9223372036854775807")] 
    [InlineData("T1T1TTT00TTT001T0T11TT10T0T01010TT101T001", "-9223372036854775808")]
    public void ParseToBigInteger_ShouldReturnCorrectValue(string ternary, string expected)
    {
        // Act
        var result = TrinaryNumber.ParseToBigInteger(ternary);

        // Assert
        result.Should().Be(BigInteger.Parse(expected));
    }

    [Theory]
    [InlineData(nameof(TrinaryNumber.ParseToInt64), "0", 0)]
    [InlineData(nameof(TrinaryNumber.ParseToInt64), "1", 1)]
    [InlineData(nameof(TrinaryNumber.ParseToInt64), "11", 4)]
    [InlineData(nameof(TrinaryNumber.ParseToInt64), "1TT", 5)]
    [InlineData(nameof(TrinaryNumber.ParseToInt64), "T11", -5)]
    [InlineData(nameof(TrinaryNumber.ParseToInt64), "111", 13)]
    [InlineData(nameof(TrinaryNumber.ParseToInt64), "TTT", -13)]
    [InlineData(nameof(TrinaryNumber.ParseToInt64), "1111", 40)]
    [InlineData(nameof(TrinaryNumber.ParseToInt64), "TTTT", -40)]
    [InlineData(nameof(TrinaryNumber.ParseToInt64), "1T1T1110011100T101TT11T01010T0T011T0T10T1", 9223372036854775807)] // Max long value
    [InlineData(nameof(TrinaryNumber.ParseToInt64), "T1T1TTT00TTT001T0T11TT10T0T01010TT101T001", -9223372036854775808)] // Min long value
    [InlineData(nameof(TrinaryNumber.ParseToInt64), "1T1TTT00TTT001T0T11TT10T0T01010TT101T001", 2934293422202152993)]
    [InlineData(nameof(TrinaryNumber.ParseToInt32), "10T1", 25)]
    [InlineData(nameof(TrinaryNumber.ParseToInt32), "T01T", -25)]
    [InlineData(nameof(TrinaryNumber.ParseToInt16), "10T1", 25)]
    [InlineData(nameof(TrinaryNumber.ParseToInt16), "T01T", -25)]
    [InlineData(nameof(TrinaryNumber.ParseToSByte), "10T1", 25)]
    [InlineData(nameof(TrinaryNumber.ParseToSByte), "T01T", -25)]

    public void ParseTo_ShouldReturnCorrectValue(string method, string ternary, long expected)
    {
        var result = typeof(TrinaryNumber).GetMethod(method)!.Invoke(null, [ternary, null]);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("111", 13)]
    [InlineData("TTT", -13)]
    public void ParseToInt3_ShouldReturnCorrectValue(string ternary, long expected)
    {
        var result = TrinaryNumber.ParseToInt3(ternary);

        result.Should().Be((IntT3)expected);
    }

    [Theory]
    [InlineData(nameof(TrinaryNumber.ParseToInt64), "1T1T1110011100T101TT11T01010T0T011T0T100T")] // Max long value + 1
    [InlineData(nameof(TrinaryNumber.ParseToInt64), "T1T1TTT00TTT001T0T11TT10T0T01010TT101T000")] // Min long value - 1
    public void ParseTo_ShouldThrowOverflowException(string method, string ternary)
    {
        Action act = () => typeof(TrinaryNumber).GetMethod(method)!.Invoke(null, [ternary, null]);

        act.Should().Throw<TargetInvocationException>().WithInnerException<OverflowException>();
    }

    [Theory]
    [InlineData("1@P-N-Z", "P", "Z", "N", "6")]
    [InlineData("+-0", "+", "0", "-", "6")]
    [InlineData("1T0", "1", "0", "T", "6")]
    public void ParseToBigInteger_ShouldRespectSettings(string ternary, string positive, string zero, string negative, string expected)
    {
        // Arrange
        var settings = new TrinarySettings
        {
            Positive = positive[0],
            Negative = negative[0],
            Zero = zero[0],
            IgnoreUnrecognizedCharacters = true,
            IgnoreWhitespace = true
        };

        // Act
        var result = TrinaryNumber.ParseToBigInteger(ternary, settings);

        // Assert
        result.Should().Be(BigInteger.Parse(expected));
    }

    [Theory]
    [InlineData("1@P-N-Z", "P", "Z", "N", 6)]
    [InlineData("+-0", "+", "0", "-", 6)]
    [InlineData("1T0", "1", "0", "T", 6)]
    public void ParseToInt64_ShouldRespectSettings(string ternary, string positive, string zero, string negative, long expected)
    {
        // Arrange
        var settings = new TrinarySettings
        {
            Positive = positive[0],
            Negative = negative[0],
            Zero = zero[0],
            IgnoreUnrecognizedCharacters = true,
            IgnoreWhitespace = true
        };

        // Act
        var result = TrinaryNumber.ParseToInt64(ternary, settings);

        // Assert
        result.Should().Be(expected);
    }

}
