namespace Trinary3.UnitTests;

public class TritTests
{
    [Fact]
    public void TritEquality()
    {
        ((int)Trit.Zero).Should().Be(0);
        ((int)Trit.Negative).Should().Be(-1);
        ((int)Trit.Positive).Should().Be(1);
    }
}