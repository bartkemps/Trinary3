namespace Trinary3.UnitTests;

using System;
using System.Numerics;

public class TrinaryNumberTests_Format
{
    [Theory]
    [InlineData(typeof(long), 6, "1T0")]
    [InlineData(typeof(long), -6, "T10")]
    [InlineData(typeof(long), long.MaxValue, "1T1T1110011100T101TT11T01010T0T011T0T10T1")]
    [InlineData(typeof(long), long.MinValue, "T1T1TTT00TTT001T0T11TT10T0T01010TT101T001")]
    [InlineData(typeof(int), int.MaxValue, "1T0TT0T000TT111T1T101")]
    [InlineData(typeof(int), int.MinValue, "T10110100011TTT1T1TT1")]
    [InlineData(typeof(short), short.MaxValue, "1TT0000TTT1")]
    [InlineData(typeof(short), short.MinValue, "T1100001101")]
    [InlineData(typeof(sbyte), sbyte.MaxValue, "1TTT01")]
    [InlineData(typeof(sbyte), sbyte.MinValue, "T111T1")]
    [InlineData(typeof(int), 6, "1T0")]
    [InlineData(typeof(int), -6, "T10")]
    [InlineData(typeof(short), (short)6, "1T0")]
    [InlineData(typeof(short), (short)-6, "T10")]
    [InlineData(typeof(sbyte), (sbyte)6, "1T0")]
    [InlineData(typeof(sbyte), (sbyte)-6, "T10")]
    public void Format_ShouldReturnCorrectTrinaryString(Type paramType, object parameter, string expected)
    {
        var settings = new TrinarySettings();
        var method = typeof(TrinaryNumber).GetMethod(nameof(TrinaryNumber.Format), [paramType, typeof(TrinarySettings)])!;

        var result = method.Invoke(null, [parameter, settings]);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(6, "1T0")]
    [InlineData(-6, "T10")]
    public void Format_ShouldFormatAnInt3(long value, string expected)
    {
        var result = TrinaryNumber.Format(value);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("-14", "T111")]
    [InlineData("-12", "TT0")]
    [InlineData("-10", "T0T")]
    [InlineData("-8", "T01")]
    [InlineData("-6", "T10")]
    [InlineData("-4", "TT")]
    [InlineData("-2", "T1")]
    [InlineData("0", "0")]
    [InlineData("2", "1T")]
    [InlineData("4", "11")]
    [InlineData("6", "1T0")]
    [InlineData("8", "10T")]
    [InlineData("10", "101")]
    [InlineData("12", "110")]
    [InlineData("14", "1TTT")]
    public void Format_ShouldReturnCorrectTrinaryString_ForBigInteger(string value, string expected)
    {
        var settings = new TrinarySettings();
        var result = TrinaryNumber.Format(BigInteger.Parse(value), settings);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Format_ShouldRespectPositiveSetting()
    {
        var settings = new TrinarySettings { Positive = 'P' };
        var result = TrinaryNumber.Format(13, settings);
        Assert.Equal("PPP", result);
    }

    [Fact]
    public void Format_ShouldRespectNegativeSetting()
    {
        var settings = new TrinarySettings { Negative = 'N' };
        var result = TrinaryNumber.Format(-4, settings);
        Assert.Equal("NN", result);
    }

    [Fact]
    public void Format_ShouldRespectZeroSetting()
    {
        var settings = new TrinarySettings { Zero = 'Z' };
        var result = TrinaryNumber.Format(0, settings);
        Assert.Equal("Z", result);
    }
}
