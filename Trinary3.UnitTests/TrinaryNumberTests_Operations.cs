namespace Trinary3.UnitTests
{
    public class TrinaryNumberTests_Operations
    {
        [Theory]
        [InlineData(6, -6)] // 6 in trinary is 1T0, negating gives T10 which is -6
        [InlineData(-6, 6)] // -6 in trinary is T10, negating gives 1T0 which is 6
        [InlineData(0, 0)] // 0 remains 0 after negation
        public void TritwiseMap_WithNegateLinearMap_ShouldNegateNumber(long value, long expected)
        {
            var result = TrinaryNumber.TritwiseMap(value, TrinaryNumber.NegateLinearMap);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(6, -22)] // 6 in trinary is 01T0, mapping gives T1TT which is -22
        [InlineData(-6, -34)] // -6 in trinary is 0T10, mapping gives TT1T which is -34
        [InlineData(0, -40)] // 0 in trinay is 0000, mapping gives TTTT which is -40
        [InlineData(-42, -43)] // -41 in trinary is T1110, mapping gives T111T which is -43
        public void TritwiseMap_WithIsPositiveLinearMap_ShouldMapToPositive(long value, long expected)
        {
            const int minimumDigits = 4;
            var result = TrinaryNumber.TritwiseMap(value, TrinaryNumber.IsPositiveLinearMap, minimumDigits);
            result.Should().Be(expected);
        }
    }
}
