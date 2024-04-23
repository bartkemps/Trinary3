namespace Trinary3.UnitTests.General
{
    using Trinary3.General;

    public class TritPairMapConverterTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(87)]
        [InlineData(-87)]
        [InlineData(9841)]
        [InlineData(-9841)]
        public void CreateTritPairMap_WithValidValue_ReturnsTritPairMap(int input)
        {
            var tritPairMap = TritPairMapConverter.CreateTritPairMap(input);
            int output = TritPairMapConverter.ToInt16(tritPairMap);
            output.Should().Be(input);
        }

    }
}
